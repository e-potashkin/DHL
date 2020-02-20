namespace DHL.Common.Models.Authentication
{
    public class MgTechnoAuthConfiguration
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool SetShortExpirationDate { get; set; }

        public string AuthUrl { get; set; }

        public string CompanyUrl { get; set; }
    }
}
