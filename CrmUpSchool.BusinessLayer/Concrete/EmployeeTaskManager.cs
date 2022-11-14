using System;
using System.Collections.Generic;
using CrmUpSchool.BusinessLayer.Abstract;
using CrmUpSchool.DataAccessLayer.Abstract;
using CrmUpSchool.UILayer.Models;

namespace CrmUpSchool.BusinessLayer.Concrete
{
	public class EmployeeTaskManager:IEmployeeTaskService
	{

        IEmployeeTaskDal _employeeTaskDal;

		public EmployeeTaskManager(IEmployeeTaskDal employeeTaskDal)
		{
            _employeeTaskDal = employeeTaskDal;
		}

        public List<EmployeeTask> TGetEmployeeTaskByEmployee()
        {
            return _employeeTaskDal.GetEmployeeTaskByEmployee();
        }

        public void TDelete(EmployeeTask t)
        {
            throw new NotImplementedException();
        }

        public EmployeeTask TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeTask> TGetList()
        {
            return _employeeTaskDal.GetList();
        }

        public void TInsert(EmployeeTask t)
        {
            _employeeTaskDal.Insert(t);
        }

        public void TUpdate(EmployeeTask t)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeTask> TGetEmployeeTaskById(int id)
        {
            return _employeeTaskDal.GetEmployeeTaskById(id);
        }
    }
}

