using System;
using System.Collections.Generic;
using CrmUpSchool.UILayer.Models;

namespace CrmUpSchool.DataAccessLayer.Abstract
{
	public interface IEmployeeTaskDal:IGenericDal<EmployeeTask>
	{
		List<EmployeeTask> GetEmployeeTaskByEmployee();
		List<EmployeeTask> GetEmployeeTaskById(int id);
	}
}

