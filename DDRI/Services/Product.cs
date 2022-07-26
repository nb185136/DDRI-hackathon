using DDRI.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DDRI.Services
{
    public class ProductService
    {
        public async Task<Product> Create(Product product)
        {
            return new Product();
        }

        public async Task<Product> Delete(int productId)
        {
            return new Product();
        }

        public async Task<Product> Update(int productId, Product product)
        {
            return new Product();
        }

        public async Task<IList<Product>> Get()
        {
            return new List<Product>();
        }

        public async Task<Product> Get(int productId)
        {
            return new Product();
        }
    }
}