using System;
using System.ComponentModel.DataAnnotations;

namespace CrmUpSchool.UILayer.Models
{
	public class RoleViewModel
	{
		public RoleViewModel()
		{
		}

		[Required(ErrorMessage="Lütfen rol adını giriniz.")]
		public string RoleName { get; set; }

	}
}

