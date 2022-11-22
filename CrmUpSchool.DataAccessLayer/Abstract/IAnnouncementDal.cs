using System;
using System.Collections.Generic;
using CrmUpSchool.EntityLayer.Concrete;

namespace CrmUpSchool.DataAccessLayer.Abstract
{
	public interface IAnnouncementDal:IGenericDal<Announcement>
	{
		public List<Announcement> ContainA();
	}
}

