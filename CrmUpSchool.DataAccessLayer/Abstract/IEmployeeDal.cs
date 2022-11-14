using System;
using System.Collections.Generic;
using CrmUpSchool.EntityLayer.Concrete;

namespace CrmUpSchool.DataAccessLayer.Abstract
{
	public interface IEmployeeDal:IGenericDal<Employee>
	{
		List<Employee> GetEmployeesByCategory();
	}
}

