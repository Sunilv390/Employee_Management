using MailKit.Net.Smtp;
using MimeKit;

namespace EmployeeManagement.Service
{
    public class SMTPService
    {
        /// <summary>
        /// SMTP integration 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mail"></param>
        /// <param name="data"></param>
        public void SendMail(string name, string mail, string data)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(name, mail));

            message.To.Add(new MailboxAddress("Employee Manegment", "sunilv390@gmail.com"));

            message.Subject = "Registration";

            message.Body = new TextPart("plain")
            {
                Text = data
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("sunilv390@gmail.com", "password");
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
