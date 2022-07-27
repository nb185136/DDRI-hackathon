using DDRI.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDRI.Models
{
    public class CustomerResponseModel : Customer
    {
        public bool isAdmin { get; set; }
    }
}