namespace DHL.Services.Models.Request
{
    public class Notification
    {
        public string Email { get; set; }

        public Notification(string email)
        {
            Email = email;
        }
    }
}
