using System;
using System.Collections.Generic;

namespace CrmUpSchool.BusinessLayer.Abstract
{
	public interface IGenericService<T>
	{
        void TInsert(T t);
        void TUpdate(T t);
        void TDelete(T t);
        List<T> TGetList();
        T TGetById(int id);
    }
}

