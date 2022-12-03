using System;
using System.Collections.Generic;
using CrmUpSchool.BusinessLayer.Abstract;
using CrmUpSchool.DataAccessLayer.Abstract;
using CrmUpSchool.EntityLayer.Concrete;

namespace CrmUpSchool.BusinessLayer.Concrete
{
	public class SupplierManager:ISupplierService
	{

        private readonly ISupplierDal _supplierDal;

        public SupplierManager(ISupplierDal supplierDal)
        {
            _supplierDal = supplierDal;
        }

        public void TDelete(Supplier t)
        {
            throw new NotImplementedException();
        }

        public Supplier TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Supplier> TGetList()
        {
            return _supplierDal.GetList();
        }

        public void TInsert(Supplier t)
        {
            _supplierDal.Insert(t);
        }

        public void TUpdate(Supplier t)
        {
            throw new NotImplementedException();
        }
    }
}

