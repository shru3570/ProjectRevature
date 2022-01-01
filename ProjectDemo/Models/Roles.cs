using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectDemo.Models
{
    public class Roles
    {
        [Key]
        public int Id  { get; set; }

        public String Name { get; set; }
    }
}