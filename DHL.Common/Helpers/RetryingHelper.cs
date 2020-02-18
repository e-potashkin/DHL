using System;
using System.Net.Http;
using System.Threading.Tasks;
using Polly;
using Polly.Retry;

namespace DHL.Common.Helpers
{
    /// <summary>
    /// Responsible for retry an operation.
    /// </summary>
    public static class RetryingHelper
    {
        /// <summary>
        /// The default attempts of retry operation.
        /// </summary>
        private const int DefaultMaxRetryAttempts = 3;

        /// <summary>
        /// The default pause between retry in milliseconds.
        /// </summary>
        private const int DefaultPauseInMilliseconds = 50;

        /// <summary>
        /// The default policy which handle the ApiException of RestEasy.
        /// </summary>
        public static AsyncRetryPolicy CreateDefaultPolicy<TException>() where TException : Exception
        {
            var pauseBetweenFailures = TimeSpan.FromMilliseconds(DefaultPauseInMilliseconds);
            return Policy
                .Handle<TException>()
                .WaitAndRetryAsync(DefaultMaxRetryAttempts, _ => pauseBetweenFailures);
        }

        /// <summary>
        /// Creates new policy. The handler of exception is the ApiException of RestEasy.
        /// </summary>
        /// <param name="maxRetryAttempts">The default attempts of retry operation.</param>
        /// <param name="pauseInMilliseconds">The default pause between retry in milliseconds.</param>
        public static AsyncRetryPolicy CreatePolicy(int maxRetryAttempts, int pauseInMilliseconds)
        {
            var pauseBetweenFailures = TimeSpan.FromMilliseconds(pauseInMilliseconds);
            return Policy
                .Handle<HttpRequestException>()
                .WaitAndRetryAsync(maxRetryAttempts, _ => pauseBetweenFailures);
        }

        /// <summary>
        /// Creates new policy.
        /// </summary>
        /// <typeparam name="TException">Type of handling exception.</typeparam>
        /// <param name="maxRetryAttempts">The default attempts of retry operation.</param>
        /// <param name="pauseInMilliseconds">The default pause between retry in milliseconds.</param>
        public static AsyncRetryPolicy CreatePolicy<TException>(int maxRetryAttempts, int pauseInMilliseconds) where TException : Exception
        {
            var pauseBetweenFailures = TimeSpan.FromMilliseconds(pauseInMilliseconds);
            return Policy
                .Handle<TException>()
                .WaitAndRetryAsync(maxRetryAttempts, _ => pauseBetweenFailures);
        }

        /// <summary>
        /// Executes operation which need retry at fail.
        /// </summary>
        /// <param name="policy">The retry policy.</param>
        /// <param name="actionAsync">The executing action.</param>
        public static async Task ExecuteWithPolicy(this AsyncRetryPolicy policy, Func<Task> actionAsync)
        {
            await policy.ExecuteAsync(async () => await actionAsync().ConfigureAwait(false)).ConfigureAwait(false);
        }

        /// <summary>
        /// Executes operation which need retry at fail and returns result.
        /// </summary>
        /// <typeparam name="TResponse">The response type.</typeparam>
        /// <param name="policy">The retry policy.</param>
        /// <param name="actionAsync">The executing action.</param>
        public static async Task<TResponse> ExecuteWithPolicy<TResponse>(this AsyncRetryPolicy policy, Func<Task<TResponse>> actionAsync)
        {
            return await policy.ExecuteAsync(async () => await actionAsync().ConfigureAwait(false)).ConfigureAwait(false);
        }
    }
}
