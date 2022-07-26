using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDRI.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int AvailableQuantity { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
        public string NextAvailability { get; set; }
    }
}