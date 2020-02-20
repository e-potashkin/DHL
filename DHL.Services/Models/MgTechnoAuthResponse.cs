namespace DHL.Services.Models
{
    public class MgTechnoAuthResponse
    {
        public int UserId { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsAuthenticated { get; set; }

        public string ReturnUrl { get; set; }

        public string AuthenticationToken { get; set; }
    }
}
