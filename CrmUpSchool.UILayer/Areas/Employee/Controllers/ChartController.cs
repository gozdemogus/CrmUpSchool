using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmUpSchool.UILayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrmUpSchool.UILayer.Areas.Employee.Controllers
{
    [AllowAnonymous]
    [Area("Employee")]
    public class ChartController : Controller
    {
        

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

      
        public IActionResult DepartmentChart()
        {
            List<DepartmentSalary> departmentSalaries = new List<DepartmentSalary>();

            departmentSalaries.Add(new DepartmentSalary
            {
                departmentname = "Muhasebe",
                salaryavg = 10000

            });

            departmentSalaries.Add(new DepartmentSalary
            {
                departmentname = "IT",
                salaryavg = 20000

            });
            departmentSalaries.Add(new DepartmentSalary
            {
                departmentname = "Satış",
                salaryavg = 12000

            });

            var x = departmentSalaries;
            return Json(new { jsonList = departmentSalaries });
        }
    }
}

