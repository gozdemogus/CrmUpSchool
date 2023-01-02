using CrmUpSchool.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;


        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUser appUser)
        {
            var result = await _signInManager.PasswordSignInAsync(appUser.UserName, appUser.PasswordHash, false, true);
            var user = await _userManager.FindByNameAsync(appUser.UserName);
            var confirmed = user.EmailConfirmed;

           // if (result.Succeeded && appUser.EmailConfirmed == true)
            if (result.Succeeded && confirmed == true)
            {
                return RedirectToAction("Index", "User");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Login");
        }

    }
}