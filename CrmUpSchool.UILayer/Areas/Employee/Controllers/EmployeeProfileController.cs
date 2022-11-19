using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CrmUpSchool.EntityLayer.Concrete;
using CrmUpSchool.UILayer.Areas.Employee.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrmUpSchool.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public EmployeeProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            //buradaki name'den kasıt kullanıcı adı
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditProfileViewModel userEditProfile = new UserEditProfileViewModel();
            userEditProfile.Name = values.Name;
            userEditProfile.Surname = values.Surname;
            userEditProfile.PhoneNumber = values.PhoneNumber;
            userEditProfile.Email = values.Email;

            return View(userEditProfile);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditProfileViewModel userEditProfileViewModel)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (userEditProfileViewModel.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(userEditProfileViewModel.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/UserImages/" + imageName;
                var stream = new FileStream(savelocation, FileMode.Create);
                await userEditProfileViewModel.Image.CopyToAsync(stream);
                user.ImageURL = imageName;
            }

            user.Name = userEditProfileViewModel.Name;
            user.Surname = userEditProfileViewModel.Surname;
            user.PhoneNumber = userEditProfileViewModel.PhoneNumber;
            user.Email = userEditProfileViewModel.Email;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditProfileViewModel.Password);
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Index","Login");
            }

            return View();
        }
    }

}