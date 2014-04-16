using Framework.Models;

namespace Framework.Interfaces
{
    public interface IEmailService
    {
        bool SendEmailMessage(EmailMessage message);
    }
}