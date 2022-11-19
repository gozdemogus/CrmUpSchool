using System;
using Microsoft.AspNetCore.Mvc;

namespace CrmUpSchool.UILayer.ViewComponents.Dashboard
{
	public class _ChartDashboardPartial:ViewComponent
	{
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

