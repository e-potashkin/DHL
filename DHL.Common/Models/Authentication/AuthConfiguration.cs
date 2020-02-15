namespace DHL.Common.Models.Authentication
{
    public class AuthConfiguration
    {
        public string User { get; set; }

        public string Signature { get; set; }

        public string ApiUser { get; set; }

        public string ApiPassword { get; set; }

        public string Url { get; set; }

        public string Base64Token { get; set; }
    }
}
