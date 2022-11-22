using System;
using System.ComponentModel.DataAnnotations;

namespace CrmUpSchool.EntityLayer.Concrete
{
	public class Announcement
	{
		public Announcement()
		{
		}
		[Key]
		public int AnnouncementID { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public DateTime Date { get; set; }
	}
}

