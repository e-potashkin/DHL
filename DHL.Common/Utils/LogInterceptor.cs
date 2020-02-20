using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Serilog;

namespace DHL.Common.Utils
{
    public class LogInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget;
            var keys = method.GetParameters().Select(x => x.Name);
            var values = invocation.Arguments;

            LogInput(keys, values, method.Name);

            invocation.Proceed();

            var isAsync = method.GetCustomAttribute(typeof(AsyncStateMachineAttribute)) != null;
            if (isAsync && typeof(Task).IsAssignableFrom(method.ReturnType))
                invocation.ReturnValue = InterceptAsync((dynamic)invocation.ReturnValue, method.Name);

            if (!isAsync) LogOutput(method.Name, invocation.ReturnValue);
        }

        private static async Task InterceptAsync(Task task, string method)
        {
            await task.ConfigureAwait(false);
            LogOutput(method);
        }

        private static async Task<T> InterceptAsync<T>(Task<T> task, string method)
        {
            var result = await task.ConfigureAwait(false);
            LogOutput(method, result);

            return result;
        }

        private static void LogInput(IEnumerable<string> keys, object[] values, string method)
        {
            var dict = new Dictionary<string, object>();

            var enumerable = keys.ToList();
            for (var i = 0; i < enumerable.Count; i++) dict.Add(enumerable[i], values[i]);

            Log.Verbose("{@method} Input: {@dict}", method, dict);
        }

        private static void LogOutput(string method)
        {
            Log.Verbose("{@method} finished", method);
        }

        private static void LogOutput<T>(string method, T result)
        {
            if (!typeof(IEnumerable).IsAssignableFrom(typeof(T))) Log.Verbose("{@method} finished with result : {@result}", method, result);
        }
    }
}
