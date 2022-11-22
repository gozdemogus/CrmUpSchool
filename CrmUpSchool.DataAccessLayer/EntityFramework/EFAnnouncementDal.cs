using System;
using System.Collections.Generic;
using System.Linq;
using CrmUpSchool.DataAccessLayer.Abstract;
using CrmUpSchool.DataAccessLayer.Concrete;
using CrmUpSchool.DataAccessLayer.Repository;
using CrmUpSchool.EntityLayer.Concrete;

namespace CrmUpSchool.DataAccessLayer.EntityFramework
{
	public class EFAnnouncementDal : GenericRepository<Announcement>, IAnnouncementDal
	{
		public EFAnnouncementDal()
		{
		}

        public List<Announcement> ContainA()
        {
            using (var context = new Context())
            {
                var values = context.Announcements.Where(x => x.Title.Contains("a")).ToList();
                return values;
            }
        }
    }
}

