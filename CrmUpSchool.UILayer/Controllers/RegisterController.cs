using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmUpSchool.EntityLayer.Concrete;
using CrmUpSchool.UILayer.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrmUpSchool.UILayer.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        //buradaki Business katmanındaki Manager değil
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public RegisterController(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

     

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignUpModel p)
        {
            Random rnd = new Random();
            int number = rnd.Next(100000, 999999);

            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    UserName = p.Username,
                    Name = p.Name,
                    Surname = p.Surname,
                    Email = p.Email,
                    PhoneNumber = p.Phonenumber,
                    MailCode = number.ToString()
                };
                if (p.Password == p.ConfirmPassword)
                {
                    var result = await _userManager.CreateAsync(appUser, p.Password);
                    if (result.Succeeded)
                    {
                        SendMail(appUser.MailCode, p.Email);
                        return RedirectToAction("EmailConfirmed", "Register");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "şifreler uyuşmuyor");
                }
            }
            return View();
        }


        public void SendMail(string emailcode, string MailReceiver)
        {
            string mailKey = _configuration["MailKey"];

            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "goezdem6@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", MailReceiver);
            mimeMessage.To.Add(mailboxAddressTo); 

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = emailcode;
            mimeMessage.Body = bodyBuilder.ToMessageBody(); 

            mimeMessage.Subject = "Üyelik Kaydı"; 

            SmtpClient smtp = new SmtpClient(); 
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate("goezdem6@gmail.com", mailKey); //kod
            smtp.Send(mimeMessage);
            smtp.Disconnect(true);
        }


        [HttpGet]
        public IActionResult EmailConfirmed()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EmailConfirmed(AppUser appUser)
        {
            var user = await _userManager.FindByEmailAsync(appUser.Email);

            if (user.MailCode == appUser.MailCode)
            {
                user.EmailConfirmed = true;

                var result = await _userManager.UpdateAsync(user);

                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}

