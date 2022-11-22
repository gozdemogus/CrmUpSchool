using System;
using System.Collections.Generic;
using CrmUpSchool.EntityLayer.Concrete;

namespace CrmUpSchool.BusinessLayer.Abstract
{
	public interface IAnnouncementService:IGenericService<Announcement>
	{
		public List<Announcement> TContainA();
	}
}

