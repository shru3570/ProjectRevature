using ProjectDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectDemo.UIMOdel
{
    public class Order
    {
        
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public String ProductName { get; set; }

        public double ProductAmount { get; set; }

        public double ProductQuantity { get; set; }
        public static List<Product> Products { get; set; }
        public double TotalBill { get; set; }

    }
}