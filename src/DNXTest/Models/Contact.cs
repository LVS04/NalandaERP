using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DNXTest.Models
{
    public class Contact
    {
        [Key]
        public Guid     Id { get; set; }
        public string   ContactName { get; set; }
        public string   Email { get; set; }
        public string   PhoneNr { get; set; }
        public string   Address { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
