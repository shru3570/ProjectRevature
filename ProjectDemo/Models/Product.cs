using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectDemo.Models
{
    public class Product
    {
        [Key]
        public int ProductId{ get; set; }
        [Required(ErrorMessage = "ProductName Is required.")]
        
        public string ProductName { get; set; }
        [Required(ErrorMessage = "ProductAmount  Is required.")]
        
        public double ProductAmount { get; set; }
        [Required(ErrorMessage = "ProductQuantity Is required.")]
        
        public double ProductQuantity { get; set; }

    }
}