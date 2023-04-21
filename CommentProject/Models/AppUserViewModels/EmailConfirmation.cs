using MimeKit;
using System.Net.Mail;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit.Text;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace CommentProject.Models.AppUserViewModels
{
    public static class EmailConfirmation
    {
        public static void SendEmail(string? link, string email)
        {

            //MailMessage mail = new MailMessage();

            //SmtpClient smtpClient = new SmtpClient("sandbox.smtp.mailtrap.io");

            //mail.From = new MailAddress("keremdrk20@gmail.com");
            //mail.To.Add(email);

            //mail.Subject = $"wwww.commentproject.com::Email Doğrulama";
            //mail.Body = "<h2>Mail doğrulaması için lütfen aşadğıdaki linke tıklayınız</h2><hr/>";
            //mail.Body = $"<a href='{link}'>email doğrulama linki</a>";
            //mail.IsBodyHtml = true;
            //smtpClient.Port = 587;
            //smtpClient.Credentials = new System.Net.NetworkCredential("keremdrk20@gmail.com", "KeremDurak26");
            //smtpClient.Send(mail);

            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("", "keremdrk20@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress("", email);
            mimeMessage.To.Add(mailboxAddressTo);


            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "<h2>Mail doğrulaması için lütfen aşadğıdaki linke tıklayınız</h2><hr/>";
            bodyBuilder.TextBody = $"{link}";
            mimeMessage.Body = bodyBuilder.ToMessageBody(); ;
            mimeMessage.Subject = $"wwww.commentproject.com::Email Doğrulama";



            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate("keremdrk20@gmail.com", "rvpkpijfpnqmvzkg");
            smtp.Send(mimeMessage);




        }
    }
}
