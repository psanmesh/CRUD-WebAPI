using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentAPI.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal MRP { get; set; }
        public int Status { get; set; }
    }
}