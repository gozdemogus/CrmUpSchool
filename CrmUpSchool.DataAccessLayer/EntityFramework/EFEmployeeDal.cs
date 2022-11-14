using System;
using System.Collections.Generic;
using System.Linq;
using CrmUpSchool.DataAccessLayer.Abstract;
using CrmUpSchool.DataAccessLayer.Concrete;
using CrmUpSchool.DataAccessLayer.Repository;
using CrmUpSchool.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CrmUpSchool.DataAccessLayer.EntityFramework
{
	public class EFEmployeeDal:GenericRepository<Employee>, IEmployeeDal
	{
		public EFEmployeeDal()
		{
		}

        public List<Employee> GetEmployeesByCategory()
        {
          using (var context=new Context())
            {
                //cagırmak istediğim entity
                return context.Employees.Include(x => x.Category).ToList();
            }
        }
    }
}

