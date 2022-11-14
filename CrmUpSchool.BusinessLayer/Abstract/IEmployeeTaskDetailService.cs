using System;
using CrmUpSchool.EntityLayer.Concrete;
using System.Collections.Generic;
using CrmUpSchool.UILayer.Models;

namespace CrmUpSchool.BusinessLayer.Abstract
{
	public interface IEmployeeTaskDetailService : IGenericService<EmployeeTaskDetail>
    {
        List<EmployeeTaskDetail> TGetEmployeeTaskDetailById(int id);
    }
}

