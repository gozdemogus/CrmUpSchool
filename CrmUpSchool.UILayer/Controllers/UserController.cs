using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CrmUpSchool.EntityLayer.Concrete;
using CrmUpSchool.UILayer.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrmUpSchool.UILayer.Controllers
{
    [Authorize(Roles = "Manager")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;


        public UserController(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            var values = await _userManager.FindByIdAsync(id);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAsync(string id)
        {
            var values = await _userManager.FindByIdAsync(id);
            return View(values);
        }


        [HttpPost]
        public async Task<IActionResult> Update(AppUser appUser)
        {
            var values = await _userManager.FindByIdAsync(appUser.Id.ToString());
            values.Name = appUser.Name;
            values.Surname = appUser.Surname;
            values.ImageURL = appUser.ImageURL;
            values.Email = appUser.Email;
            values.PhoneNumber = appUser.PhoneNumber;
           await _userManager.UpdateAsync(values);

            return View();
        }

        public IActionResult Settings()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

      
        public async Task<IActionResult> Delete()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {

                return View();
            }
        }

 
        public async Task<IActionResult> DeleteById(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var result = await _userManager.DeleteAsync(user);

            return RedirectToAction("Index");
        }


        // GET: /<controller>/
        public async Task<IActionResult> ChangePassword()
        {
            //  var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> ChangePassword(EditPasswordViewModel editPasswordViewModel)
        {
            var url = "";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (editPasswordViewModel.NewPassword == editPasswordViewModel.ConfirmNewPassword)
            {
                var updateUser = await _userManager.ResetPasswordAsync(user, token, editPasswordViewModel.NewPassword);
                if (updateUser.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            else
            {
                ModelState.AddModelError("", "An error occured.");
            }
            return RedirectToAction("Index", "Register");

        }


        public void SendMail(string email, string link)
        {
            string mailKey = _configuration["MailKey"];

            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("CRM Service", "goezdem6@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", email);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            //  bodyBuilder.TextBody = emailcode;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = "Password Reset";

            var body = new TextPart("plain")
            {
                Text = link
            };

            mimeMessage.Body = body;

            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587, false);
                smtp.Authenticate("goezdem6@gmail.com", mailKey); //kod
                smtp.Send(mimeMessage);
                smtp.Disconnect(true);
            }


        }


        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([Required] string email)
        {
            if (!ModelState.IsValid)
                return View(email);

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return RedirectToAction(nameof(ForgotPasswordConfirmation));

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var link = Url.Action("ResetPassword", "User", new { token, email = user.Email }, Request.Scheme);
            // var link = $"https://localhost:5001/Password/ResetPassword/{token}/{email}";

            SendMail(user.Email, link);

            //if (emailResponse)
            //    return RedirectToAction("ForgotPasswordConfirmation");
            //else
            //{
            //    // log email failed 
            //}
            return RedirectToAction("ForgotPasswordConfirmation");
        }

        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        //   [Route("Password/ResetPassword/{token}/{email}")]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPassword { Token = token, Email = email };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPassword resetPassword)
        {
            if (!ModelState.IsValid)
                return View(resetPassword);

            var user = await _userManager.FindByEmailAsync(resetPassword.Email);
            if (user == null)
                RedirectToAction("ResetPasswordConfirmation");

            var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);
            if (!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                    ModelState.AddModelError(error.Code, error.Description);
                return View();
            }

            return RedirectToAction("ResetPasswordConfirmation");
        }

        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
    }

}

