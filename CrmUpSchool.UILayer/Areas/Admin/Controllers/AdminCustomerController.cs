using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmUpSchool.BusinessLayer.Abstract;
using CrmUpSchool.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrmUpSchool.UILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminCustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public AdminCustomerController(ICustomerService customerService)
        {
           _customerService = customerService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CustomerList()
        {
            var jsonCustomers = JsonConvert.SerializeObject(_customerService.TGetList());

            return Json(jsonCustomers);
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            _customerService.TInsert(customer);

            var values = JsonConvert.SerializeObject(customer);

            return Json(values);
        }

        public IActionResult GetById(int CustomerID)
        {
            var values = _customerService.TGetById(CustomerID);

            var jsonValues = JsonConvert.SerializeObject(values);

            return Json(jsonValues);
        }

        public IActionResult DeleteCustomer(int id)
        {
            var values = _customerService.TGetById(id);

            _customerService.TDelete(values);

            return Json(values);
        }

        public IActionResult UpdateCustomer(Customer customer)
        {
            _customerService.TUpdate(customer);

            var values = JsonConvert.SerializeObject(customer);

            return Json(values);
        }


    }
}

