using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Implementations;
using Framework.Interfaces;
using Framework.Models;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class EmailTests
    {
        private readonly IEmailService _emailService;

        public EmailTests()
        {
            _emailService = new GmailEmailService();
        }

        [Test]
        public void send_email_via_gmail()
        {
            var email = new EmailMessage
            {
                IsHtml = false,
                Subject = "Gmail unit test email",
                ToEmail = "your.test.email@gmail.com",
                Body = String.Format("Gmail unit test body sent at {0:D}", DateTime.Now)
            };
            var success = _emailService.SendEmailMessage(email);
            Assert.IsTrue(success);
        }
    }
}
