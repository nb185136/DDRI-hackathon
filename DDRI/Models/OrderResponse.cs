using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDRI.Models
{
    public class OrderResponse
    {
        public int OrderId { get; set; }
        public int OrderTotal { get; set; }
        public List<CartItems> CartItems { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
    }
}