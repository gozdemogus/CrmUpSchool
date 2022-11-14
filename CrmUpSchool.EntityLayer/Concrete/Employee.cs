using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CrmUpSchool.UILayer.Models;

namespace CrmUpSchool.EntityLayer.Concrete
{
	public class Employee
	{
		public Employee()
		{
		}

		[Key]
		public int EmployeeID { get; set; }
		public string EmployeeName { get; set; }
		public string EmployeeSurname { get; set; }
		public string EmployeeMail { get; set; }
		public string EmployeeImage { get; set; }

		//Employee tablosunda bir Category sütunu olacak
		public int CategoryID { get; set; }
		//iliskili hale getirebilmek icin iliski icine almak istenen entity ismi getirilmeli
		//ve Category tarafında da iliski belirtilmeli...
		public Category Category { get; set; }

		public bool EmployeeStatus { get; set; }

    }
}

