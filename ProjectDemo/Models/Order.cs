using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectDemo.Models
{
    public class Order
    {
        [Key]
        public int OrderId{ get; set; }

        
        public DateTime OrderDate { get; set; }

        public int OrderBy { get; set; }

        public string OrderDetails { get; set; }
        public string Status { get; set; }

        public DateTime DeliveryDate { get; set; }
        public string DelivaryAddress { get; set; }
        public double TotalBill { get; set; }

    }
}