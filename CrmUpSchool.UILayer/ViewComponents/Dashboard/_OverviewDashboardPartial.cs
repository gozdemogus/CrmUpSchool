using System;
using System.Linq;
using CrmUpSchool.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CrmUpSchool.UILayer.ViewComponents.Dashboard
{
    public class _OverviewDashboardPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using (var context = new Context())
            {
                ViewBag.EmployeeCount = context.Employees.Count();
                ViewBag.EmployeeWomanGenderCount = context.Users.Where(x => x.Gender == "F").Count();
                int id = context.Users.Max(x => x.Id);
                ViewBag.LastUser = context.Users.Where(x => x.Id == id).Select(x => x.Name + " " + x.Surname).FirstOrDefault();

            }
            return View();
        }
    }
}

