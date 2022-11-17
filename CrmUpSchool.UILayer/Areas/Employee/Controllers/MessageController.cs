using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using CrmUpSchool.BusinessLayer.Abstract;
using CrmUpSchool.DataAccessLayer.Concrete;
using CrmUpSchool.EntityLayer.Concrete;
using CrmUpSchool.UILayer.Areas.Employee.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrmUpSchool.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<AppUser> _userManager;

        public MessageController(IMessageService messageService, UserManager<AppUser> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }


        // GET: /<controller>/
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(Message m)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            m.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            m.SenderEmail = user.Email;
            m.SenderName = user.Name + " " + user.Surname;

            using (var context = new Context())
            {
               m.ReceiverName =  context.Users.Where(x => x.Email == m.ReceiverEmail).Select(x => x.Name + " " + x.Surname).FirstOrDefault();
            }
            _messageService.TInsert(m);
            return RedirectToAction("SendMessage");
        }

        [HttpGet]
        public async Task<IActionResult> SendEMail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEMail(MailRequest m)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailBoxAddressFrom = new MailboxAddress("Admin", "gozdemog@gmail.com");
            mimeMessage.From.Add(mailBoxAddressFrom);

            MailboxAddress mailBoxAddressTo = new MailboxAddress("User", m.ReceiverEmail);
            mimeMessage.To.Add(mailBoxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = m.EmailContent;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = m.EmailSubject;
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("gozdemog@gmail.com", "sirijhxmwekgmmbe");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();
        }

    }
}

