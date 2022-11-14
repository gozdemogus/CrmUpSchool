using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmUpSchool.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrmUpSchool.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeTaskDetailController : Controller
    {
        private readonly IEmployeeTaskDetailService _employeeTaskDetailService;

        public EmployeeTaskDetailController(IEmployeeTaskDetailService employeeTaskDetailService)
        {
            _employeeTaskDetailService = employeeTaskDetailService;
        }

        // GET: /<controller>/
        public IActionResult Index(int id)
        {
            var values = _employeeTaskDetailService.TGetEmployeeTaskDetailById(id);
            return View(values);
        }
    }
}

