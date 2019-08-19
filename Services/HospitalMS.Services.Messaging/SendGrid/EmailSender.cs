using HospitalMS.Common;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace HospitalMS.Services.Messaging.SendGrid
{
    public class EmailSender : IEmailSender
    {
        private SendGridOptions options;

        public EmailSender(IOptions<SendGridOptions> options)
        {
            this.options = options.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var apiKey = this.options.ApiKey;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(GlobalConstants.AdminEmail, GlobalConstants.AdminUserName);
            var to = new EmailAddress(email, email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, htmlMessage, htmlMessage);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
