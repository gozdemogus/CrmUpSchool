using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmUpSchool.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrmUpSchool.UILayer.ViewComponents
{
    public class UserHeader : ViewComponent
    {

        private readonly UserManager<AppUser> _userManager;

        public UserHeader(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }
    }
}

