using DDRI.DBObjects;
using DDRI.Models;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace DDRI.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        DDRIEntities db = new DDRIEntities();
        Services.ProductService _product = new Services.ProductService();

        [Route("addorupdate")]
        [HttpPost]
        public async Task<IHttpActionResult> Create(Product pto)
        {
            try
            {

                if (pto.ID == 0)
                {
                    await _product.Create(new Product()
                    {
                    });


                }
                else
                {
                    await _product.Update(new Product()
                    {
                    });
                }
                return Ok();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return Ok((int)HttpStatusCode.InternalServerError);
            }


        }

        [Route("details")]
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var a = db.Customers.ToList();
            return Ok();
        }

        [Route("detailById")]
        [HttpGet]
        public async Task<IHttpActionResult> GetCustomerbyId(int id)
        {
            var obj = db.Customers.Where(x => x.Id == id).ToList().FirstOrDefault();
            return Ok();
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IHttpActionResult> delete(int id)
        {
            var obj = db.Customers.Where(x => x.Id == id).ToList().FirstOrDefault();
            db.Customers.Remove(obj);
            db.SaveChanges();
            return Ok();
        }

    }
}