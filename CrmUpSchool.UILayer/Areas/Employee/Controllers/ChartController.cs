using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmUpSchool.UILayer.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrmUpSchool.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class ChartController : Controller
    {
        List<DepartmentSalary> departmentSalaries = new List<DepartmentSalary>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DepartmentChart()
        {
            departmentSalaries.Add(new DepartmentSalary
            {
                deparmantname = "Muhasebe",
                salaryavg = 10000

            });

            departmentSalaries.Add(new DepartmentSalary
            {
                deparmantname = "IT",
                salaryavg = 20000

            });
            departmentSalaries.Add(new DepartmentSalary
            {
                deparmantname = "Satış",
                salaryavg = 12000

            });


            return Json(new { jsonList = departmentSalaries });
        }
    }
}

