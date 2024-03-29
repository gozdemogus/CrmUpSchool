﻿using System;
using System.ComponentModel.DataAnnotations;

namespace CrmUpSchool.UILayer.Models
{
	public class EditPasswordViewModel
	{
		public EditPasswordViewModel()
		{
		}


        [Required(ErrorMessage = "Existing Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "New Password")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "New Password Confirm")]
        [Compare("NewPassword", ErrorMessage = "Passwords must match")]
        public string ConfirmNewPassword { get; set; }
        public string Token { get; set; }
    }
}

