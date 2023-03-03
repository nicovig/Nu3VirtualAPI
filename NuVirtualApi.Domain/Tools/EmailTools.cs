using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace NuVirtualApi.Domain.Tools
{
    public static class EmailTools
    {
        public static bool SendNewPasswordEmail(string newpassword)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("benedict42@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("benedict42@ethereal.email"));
            email.Subject = "Test";
            email.Body = new TextPart(TextFormat.Html) { Text = "Bonjour, votre nouveau mot de passe est : " + newpassword };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("benedict42@ethereal.email", "6dxgJWZCmwKh8GEATC");
            var result = smtp.Send(email);
            smtp.Disconnect(true);

            if (result.Contains("ACCEPTED"))
            {
                return true;
            }

            return false;
        }
    }
}
