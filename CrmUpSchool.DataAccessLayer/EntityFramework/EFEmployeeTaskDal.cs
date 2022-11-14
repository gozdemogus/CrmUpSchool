using System;
using System.Collections.Generic;
using System.Linq;
using CrmUpSchool.DataAccessLayer.Abstract;
using CrmUpSchool.DataAccessLayer.Concrete;
using CrmUpSchool.DataAccessLayer.Repository;
using CrmUpSchool.EntityLayer.Concrete;
using CrmUpSchool.UILayer.Models;
using Microsoft.EntityFrameworkCore;

namespace CrmUpSchool.DataAccessLayer.EntityFramework
{
    public class EFEmployeeTaskDal : GenericRepository<EmployeeTask>, IEmployeeTaskDal
    {
        public EFEmployeeTaskDal()
        {
        }
        public List<EmployeeTask> GetEmployeeTaskByEmployee()
        {
            using (var context = new Context())
            {
                var values = context.EmployeeTasks.Include(x => x.AppUser).ToList();
                return values;
            }
        }

        public List<EmployeeTask> GetEmployeeTaskById(int id)
        {
            using (var context = new Context())
            {
                var values = context.EmployeeTasks.Where(x => x.AppUserId == id).ToList();
                return values;
            }
        }
    }
}

