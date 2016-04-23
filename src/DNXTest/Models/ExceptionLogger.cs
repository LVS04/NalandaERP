using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DNXTest.Models
{
    public class ExceptionLogger
    {
        [Key]
        public  int         Id                  { get; set; }
        public  string      ExceptionMessage    { get; set; }
        public  string      ControllerName      { get; set; }
        public  string      ExceptionStackTrace { get; set; }
        public  string      EmailUser           { get; set; }
        public  DateTime    LogTime             { get; set; }
    }
}
