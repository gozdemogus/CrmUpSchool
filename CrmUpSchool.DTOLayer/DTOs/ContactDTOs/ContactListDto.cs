using System;
namespace CrmUpSchool.DTOLayer.DTOs.ContactDTOs
{
	public class ContactListDto
	{
		public ContactListDto()
		{
		}

        public int ContactID { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
    }
}

