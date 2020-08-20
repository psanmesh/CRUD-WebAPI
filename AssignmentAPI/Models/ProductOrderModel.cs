using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentAPI.Models
{
    public class ProductOrderModel
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal MRP { get; set; }
        public int QTY { get; set; }
        public decimal Amount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal PayableAmount { get; set; }
        public int Mode { get; set; }
        public string ModeName { get; set; }
    }
}