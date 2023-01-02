using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmUpSchool.BusinessLayer.Abstract;
using CrmUpSchool.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrmUpSchool.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeTaskController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmployeeTaskService _employeeTaskService;

        public EmployeeTaskController(UserManager<AppUser> userManager, IEmployeeTaskService employeeTaskService)
        {
            _userManager = userManager;
            _employeeTaskService = employeeTaskService;
          
        }

        public async Task<IActionResult> EmployeeTaskListByProfile()
        {
            //login olmus kullanıcı bilgileri
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var taskList = _employeeTaskService.TGetEmployeeTaskById(values.Id);

            return View(taskList);
        }


        public async Task<IActionResult> EmployeeTaskListById(int id)
        {
            
            var values = await _userManager.FindByIdAsync(id.ToString());
            var taskList = _employeeTaskService.TGetEmployeeTaskById(id);
            ViewBag.UserName = values.UserName;
            return View(taskList);
        }

    }


}

