using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using SignalRWebUI.Dtos.MailDtos;

namespace SignalRWebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            var mimeMessage = new MimeMessage();

            // Gönderen bilgileri
            var mailboxAddressFrom = new MailboxAddress("SignalR Rezervasyon", "alphanellik199@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            // Alıcı bilgileri
            var mailboxAddressTo = new MailboxAddress("Alıcı", createMailDto.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            // Mail içeriği
            var bodyBuilder = new BodyBuilder
            {
                TextBody = createMailDto.Body
            };
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = createMailDto.Subject;

            // Mail gönderme işlemi
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate("alphanellik199@gmail.com", "ncen ford kcwz utoo"); // Gmail için Uygulama Şifresi gerekli!
                client.Send(mimeMessage); // Mail gönderme işlemi eklendi!
                client.Disconnect(true);
            }

            return RedirectToAction("Index", "Product");
        }
    }
}