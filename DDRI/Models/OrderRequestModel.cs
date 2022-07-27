using DDRI.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDRI.Models
{
    public class OrderRequestModel
    {
        public List<CartItems> Products { get; set; }

        public int DeliveryMins { get; set; }

    }
}