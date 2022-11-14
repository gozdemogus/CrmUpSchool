using System;
using System.Collections.Generic;
using CrmUpSchool.BusinessLayer.Abstract;
using CrmUpSchool.DataAccessLayer.Abstract;
using CrmUpSchool.DataAccessLayer.EntityFramework;
using CrmUpSchool.EntityLayer.Concrete;

namespace CrmUpSchool.BusinessLayer.Concrete
{
	public class EmployeeTaskDetailManager:IEmployeeTaskDetailService
	{
        private readonly IEmployeeTaskDetailDal _employeeTaskDetailDal;

        public EmployeeTaskDetailManager(IEmployeeTaskDetailDal employeeTaskDetailDal)
        {
            _employeeTaskDetailDal = employeeTaskDetailDal;
        }

        public void TDelete(EmployeeTaskDetail t)
        {
            throw new NotImplementedException();
        }

        public EmployeeTaskDetail TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeTaskDetail> TGetEmployeeTaskDetailById(int id)
        {
            return _employeeTaskDetailDal.GetEmployeeTaskDetailById(id);
        }

        public List<EmployeeTaskDetail> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(EmployeeTaskDetail t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(EmployeeTaskDetail t)
        {
            throw new NotImplementedException();
        }
    }
}

