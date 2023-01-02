using System;
using System.ComponentModel.DataAnnotations;

namespace CrmUpSchool.UILayer.Models
{
	public class ForgotPasswordModel
	{
		public ForgotPasswordModel()
		{
		}
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

