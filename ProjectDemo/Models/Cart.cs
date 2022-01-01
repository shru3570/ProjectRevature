using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectDemo.Models
{
    public class Cart
    {
        [Key]
        public int ProductId { get; set; }
        public int UserId { get; set; }

        public String ProductName{ get; set; }

        public double ProductAmount { get; set; }

        public double ProductQuantity { get; set; }

        public bool Isdeleteted { get; set; }

    }
}