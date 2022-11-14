using System;
using System.Collections.Generic;
using CrmUpSchool.EntityLayer.Concrete;

namespace CrmUpSchool.BusinessLayer.Abstract
{
	public interface IEmployeeService : IGenericService<Employee>
	{
        List<Employee> TGetEmployeesByCategory();
    }
	
}

