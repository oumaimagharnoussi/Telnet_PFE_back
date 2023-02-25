namespace Ticketback.Models
{
    public record ResetPassword
    {
        public string email { get; set; }
        public string EmailToken { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPasswrd { get; set; }
    }
}
