using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmUpSchool.BusinessLayer.Abstract;
using CrmUpSchool.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrmUpSchool.UILayer.Controllers
{
    [Authorize(Roles = "Manager")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var values = _announcementService.TGetList();
            return View(values);
        }


        public IActionResult Detail(int id)
        {
            var values = _announcementService.TGetById(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var values = _announcementService.TGetById(id);
            return View(values);
        }


        [HttpPost]
        public IActionResult Update(Announcement announcement)
        {
            var value = _announcementService.TGetById(announcement.AnnouncementID);
            value.Content = announcement.Content;
            value.Title = announcement.Title;
            value.Date = DateTime.Now;
            _announcementService.TUpdate(value);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult NewAnnouncement()
        {
           
            return View();
        }



        [HttpPost]
        public IActionResult NewAnnouncement(Announcement announcement)
        {
            announcement.Date = DateTime.Now;
            _announcementService.TInsert(announcement);
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var announcement = _announcementService.TGetById(id);
            _announcementService.TDelete(announcement);
            return RedirectToAction("Index");
        }

    }
}

