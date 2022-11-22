using System;
using CrmUpSchool.BusinessLayer.Abstract;
using CrmUpSchool.BusinessLayer.Concrete;
using CrmUpSchool.DataAccessLayer.Abstract;
using CrmUpSchool.DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace CrmUpSchool.BusinessLayer.DIContainer
{
	public static class Extensions
	{
	
		public static void ContainerDependencies(this IServiceCollection services)
		{
            //CategoryService gördüğün yerde CategoryManager'ı çağır
            //Interface'ler ve miras alınan sınıfları tanımla
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EFCategoryDal>();

            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<IEmployeeDal, EFEmployeeDal>();

            services.AddScoped<IEmployeeTaskService, EmployeeTaskManager>();
            services.AddScoped<IEmployeeTaskDal, EFEmployeeTaskDal>();

            services.AddScoped<IEmployeeTaskDetailService, EmployeeTaskDetailManager>();
            services.AddScoped<IEmployeeTaskDetailDal, EFEmployeeTaskDetailDal>();

            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IMessageDal, EFMessageDal>();

            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EFAnnouncementDal>();
        }
	}
}

