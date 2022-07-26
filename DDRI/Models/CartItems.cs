using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDRI.Models
{
    public class CartItems
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}