using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstWebApi.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderCreateDate { get; set; }
        public bool IsActive { get; set; }
        public int OrderStatus { get; set; }
    }
}