using System;
using System.Collections.Generic;
using System.Linq;
using CrmUpSchool.DataAccessLayer.Abstract;
using CrmUpSchool.DataAccessLayer.Concrete;
using CrmUpSchool.DataAccessLayer.Repository;
using CrmUpSchool.EntityLayer.Concrete;
using CrmUpSchool.UILayer.Models;

namespace CrmUpSchool.DataAccessLayer.EntityFramework
{
    public class EFEmployeeTaskDetailDal : GenericRepository<EmployeeTaskDetail>, IEmployeeTaskDetailDal
    {
       
        public List<EmployeeTaskDetail> GetEmployeeTaskDetailById(int id)
        {
            using (var context = new Context())
            {
               var aaa = context.EmployeeTaskDetails.Where(x => x.EmployeeTaskID == id).ToList();
                return aaa;
            }
        }

    }
}

