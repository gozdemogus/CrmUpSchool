using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmUpSchool.BusinessLayer.Abstract;
using CrmUpSchool.EntityLayer.Concrete;
using CrmUpSchool.UILayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrmUpSchool.UILayer.Controllers
{
    public class EmployeeTaskController : Controller
    {

        private readonly IEmployeeTaskService _employeeTaskService;
        private readonly UserManager<AppUser> _userManager;


        public EmployeeTaskController(IEmployeeTaskService employeeTaskService, UserManager<AppUser> userManager)
        {
            _employeeTaskService = employeeTaskService;
            _userManager = userManager;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var values = _employeeTaskService.TGetEmployeeTaskByEmployee();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            List<SelectListItem> userValues = (from x in _userManager.Users.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name + " " + x.Surname,
                                                       Value = x.Id.ToString()
                                                   }).ToList();
            ViewBag.v = userValues;
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(EmployeeTask employeeTask)
        {
            employeeTask.Status = "Görev Atandı";
            employeeTask.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _employeeTaskService.TInsert(employeeTask);
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var task = _employeeTaskService.TGetById(id);
           _employeeTaskService.TDelete(task);
            return View("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            List<SelectListItem> userValues = (from x in _userManager.Users.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name + " " + x.Surname,
                                                   Value = x.Id.ToString()
                                               }).ToList();
            ViewBag.v = userValues;
            var task = _employeeTaskService.TGetById(id);
            return View(task);
        }

        [HttpPost]
        public IActionResult Update(EmployeeTask employeeTask)
        {
            var taskTarget = _employeeTaskService.TGetById(employeeTask.EmployeeTaskID);
    
            taskTarget.Title = employeeTask.Title;
            taskTarget.Date = employeeTask.Date;
            taskTarget.Details = employeeTask.Details;
            _employeeTaskService.TUpdate(taskTarget);
            return RedirectToAction("Index");
        }
    }
}

