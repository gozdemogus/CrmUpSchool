using System;
using Microsoft.AspNetCore.Identity;

namespace CrmUpSchool.EntityLayer.Concrete
{
	public class AppUser:IdentityUser<int>
	{
		public AppUser()
		{
		}

		public string Name { get; set; }
		public string Surname { get; set; }
		public string ImageURL { get; set; }
		public string Gender { get; set; }

	}
}

