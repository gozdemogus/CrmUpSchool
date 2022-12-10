using System;
namespace CrmUpSchool.DTOLayer.DTOs.ContactDTOs
{
	public class ContactAddDto
	{
		public ContactAddDto()
		{
		}

        public string Name { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}

