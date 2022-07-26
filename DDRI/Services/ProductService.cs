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
        private DDRIEntities _db = null;
        public ProductService()
        {
            _db = new DDRIEntities();
        }
        public async Task<Product> Create(Product product)
        {
            Product p = new Product();
            p.ID = product.ID;
            p.Name = product.Name;
            p.Price = product.Price;
            p.AvailableQuantity = product.AvailableQuantity;
            p.NextAvailability = product.NextAvailability;
            p.CreatedOn = System.DateTime.Now;
            p.UpdatedOn = System.DateTime.Now;
            _db.Products.Add(p);
            _db.SaveChanges();
            return p;
        }

        public async Task<Product> Delete(int productId)
        {
            var obj = _db.Products.Where(x => x.ID == productId).ToList().FirstOrDefault();
            _db.Products.Remove(obj);
            _db.SaveChanges();
            return obj;
        }

        public async Task<Product> Update(Product product)
        {
            var obj = _db.Products.Where(x => x.ID == product.ID).ToList().FirstOrDefault();
            if (obj.ID > 0)
            {

                obj.Name = product.Name;
                obj.Price = product.Price;
                obj.AvailableQuantity = product.AvailableQuantity;
                obj.NextAvailability = product.NextAvailability;
                _db.SaveChanges();
            }
            return obj;
        }

        public async Task<IList<Product>> Get()
        {
            var a = _db.Products.ToList();
            return a;
        }

        public async Task<Product> GetProductById(int productId)
        {
            var obj = _db.Products.Where(x => x.ID == productId).ToList().FirstOrDefault();
            return obj;
        }
    }
}