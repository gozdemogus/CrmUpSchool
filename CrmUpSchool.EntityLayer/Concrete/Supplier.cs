using System;
using System.ComponentModel.DataAnnotations;

namespace CrmUpSchool.EntityLayer.Concrete
{
    public class Supplier
    {
        [Key]
        public int SuppilerID { get; set; }
        public string SuppilerCompanyName { get; set; }
        public string SuppilerCity { get; set; }
        public string SuppilerPhone { get; set; }
        public string SuppilerMail { get; set; }
        public string SuppilerContactName { get; set; }
    }
}

