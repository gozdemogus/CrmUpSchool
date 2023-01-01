using CrmUpSchool.BusinessLayer.Abstract;
using CrmUpSchool.DataAccessLayer.Concrete;
using CrmUpSchool.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CrmUpSchool.UILayer.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        Context c = new Context();

        public IActionResult Index()
        {
            var values = c.Customers.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Add()
        {
          
            return View();
        }

        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            _customerService.TInsert(customer);
            return RedirectToAction("Index");
        }
    }
}
