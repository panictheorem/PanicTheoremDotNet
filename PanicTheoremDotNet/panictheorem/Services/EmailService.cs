using panictheorem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Threading.Tasks;

namespace panictheorem.Services
{
    public class EmailService
    {
        public EmailService() { }

        public async static Task<int> SendContactForm(ContactForm contactForm){
                var body = "<p>Email from {0} ({1})</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("andrewpineau@hotmail.com"));
                message.From = new MailAddress("postmaster@panictheorem.net");
                message.Subject = "PanicTheorem.Net Message";
                message.Body = string.Format(body, contactForm.Name, contactForm.Email, contactForm.Message);
                message.IsBodyHtml = true;

                using (var smtpClient = new SmtpClient())
                {
                    await smtpClient.SendMailAsync(message);
                }
                return 0;
        }
    }
}