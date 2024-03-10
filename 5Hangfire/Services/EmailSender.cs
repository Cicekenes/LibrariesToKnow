using SendGrid.Helpers.Mail;
using SendGrid;

namespace _5Hangfire.Services
{
    public class EmailSender : IEmailSender
    {
        //58D5A9DY4RBEM5N78H57ES3H
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Sender(string userId, string message)
        {
            //bu user id'ye sahip kullanıcıyı bul ve email adresini yaz.
            var apiKey = _configuration.GetSection("APIs")["SendGridApi"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("mailadress", "Example User");
            var subject = "www.mysite.com bilgilendirme";
            var to = new EmailAddress("mailadress", "Example User");
            //var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = $"<strong>{message}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
            await client.SendEmailAsync(msg);
        }
    }
}
