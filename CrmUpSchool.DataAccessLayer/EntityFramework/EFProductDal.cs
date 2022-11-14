using System;
using CrmUpSchool.DataAccessLayer.Abstract;
using CrmUpSchool.DataAccessLayer.Repository;
using CrmUpSchool.EntityLayer.Concrete;

namespace CrmUpSchool.DataAccessLayer.EntityFramework
{
	public class EFProductDal:GenericRepository<Product>,IProductDal
	{
		public EFProductDal()
		{
		}

        public void GetProductByCategory()
        {
            throw new NotImplementedException();
        }
    }
}

