using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmUpSchool.BusinessLayer.Abstract;
using CrmUpSchool.DTOLayer.DTOs.ContactDTOs;
using CrmUpSchool.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrmUpSchool.UILayer.Areas.Admin.Controllers
{

    [Area("Admin")]
    [AllowAnonymous]
    public class ContactController : Controller
    {

        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(ContactAddDto model)
        {
            if (ModelState.IsValid)
            {
                _contactService.TInsert(new Contact()
                {
                    Name = model.Name,
                    Mail = model.Mail,
                    Content = model.Content,
                    Subject = model.Subject,
                    Date = DateTime.Parse(DateTime.Now.ToShortDateString())
                });

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

