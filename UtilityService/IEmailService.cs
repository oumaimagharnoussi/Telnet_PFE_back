using Ticketback.Models;

namespace Ticketback.UtilityService
{
    public interface IEmailService
    {
        void SendEmail(EmailModel emailModel); 
    }
}
