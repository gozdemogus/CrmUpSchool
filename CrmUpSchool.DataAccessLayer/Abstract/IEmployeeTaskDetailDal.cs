using System;
using CrmUpSchool.EntityLayer.Concrete;
using System.Collections.Generic;

namespace CrmUpSchool.DataAccessLayer.Abstract
{
	public interface IEmployeeTaskDetailDal:IGenericDal<EmployeeTaskDetail>
	{
        List<EmployeeTaskDetail> GetEmployeeTaskDetailById(int id);
    }
}

