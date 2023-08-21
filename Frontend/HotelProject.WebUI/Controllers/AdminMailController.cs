using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MimeKit;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            //Mail Gönderme İşlemleri

            MimeMessage mimeMessage = new MimeMessage();
            //Mail Kimden Gelecek
            MailboxAddress mailboxAddressFrom = new MailboxAddress("HoteilerAdmin", "34fatih58@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            //Mail Kime Gidecek
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            //Mail İçerik
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = model.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = model.Subject;
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("34fatih58@gmail.com", "swiliibiytpqakkk");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
            //Gönderilen Mailin Veri Tabanına Kaydedilmesi
        }
    }
}
