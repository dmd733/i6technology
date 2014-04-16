using Framework.Interfaces;
using Framework.Models;

namespace Framework.Implementations.Mocks
{
    public class MockEmailService : IEmailService
    {

        public bool SendEmailMessage(EmailMessage message)
        {
            return true;
        }
    }
}