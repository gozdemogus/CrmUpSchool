using System;
namespace CrmUpSchool.EntityLayer.Concrete
{
	public class Message
	{
		public Message()
		{
		}
		public int MessageID { get; set; }
		public string MessageSubject { get; set; }
		public string MessageContext { get; set; }
		public string ReceiverName { get; set; }
		public string ReceiverEmail { get; set; }
		public string SenderName { get; set; }
		public string SenderEmail { get; set; }
		public DateTime Date { get; set; }
	}
}

