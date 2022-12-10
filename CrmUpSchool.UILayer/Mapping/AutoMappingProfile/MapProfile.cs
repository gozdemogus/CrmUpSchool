using System;
using AutoMapper;
using CrmUpSchool.DTOLayer.CustomerDTOs;
using CrmUpSchool.DTOLayer.DTOs.ContactDTOs;
using CrmUpSchool.EntityLayer.Concrete;

namespace CrmUpSchool.UILayer.Mapping.AutoMappingProfile
{
	public class MapProfile:Profile
	{
		public MapProfile()
		{
			CreateMap<ContactAddDto, Contact>();
			CreateMap<Contact, ContactAddDto>();

			CreateMap<ContactListDto, Contact>();
			CreateMap<Contact, ContactListDto>();

			CreateMap<ContactUpdateDto, Contact>();
			CreateMap<Contact, ContactUpdateDto>();

			CreateMap<CustomerAddDto, Customer>();
			CreateMap<Customer, ContactUpdateDto>();
		}


	}
}

