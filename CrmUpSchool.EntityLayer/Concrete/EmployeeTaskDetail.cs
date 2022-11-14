using System;
using CrmUpSchool.UILayer.Models;

namespace CrmUpSchool.EntityLayer.Concrete
{
	public class EmployeeTaskDetail
	{
		public EmployeeTaskDetail()
		{
		}

		public int EmployeeTaskDetailID { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; }
		public int EmployeeTaskID { get; set; }
		public EmployeeTask EmployeeTask { get; set; }
	}
}

