﻿using System;
using CrmUpSchool.DataAccessLayer.Abstract;
using CrmUpSchool.DataAccessLayer.Repository;
using CrmUpSchool.EntityLayer.Concrete;

namespace CrmUpSchool.DataAccessLayer.EntityFramework
{
	public class EFMessageDal:GenericRepository<Message>,IMessageDal
	{
		public EFMessageDal()
		{
		}
	}
}

