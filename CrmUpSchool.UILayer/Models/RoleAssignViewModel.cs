using System;
namespace CrmUpSchool.UILayer.Models
{
	public class RoleAssignViewModel
	{
		public RoleAssignViewModel()
		{
		}

		public int RoleID { get; set; }
		public string Name { get; set; }
		public bool Exists { get; set; }
	}
}

