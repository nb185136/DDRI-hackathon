using DDRI.DBObjects;
using DDRI.Models;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace DDRI.Controllers
{
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        DDRIEntities db = new DDRIEntities();
        Services.Customer _customer = new Services.Customer();

        [Route("addorUpdate")]
        [HttpPost]
        public async Task<IHttpActionResult> AddorEdit(CustomerDto cto)
        {
            try
            {

                if (cto.Id == 0)
                {
                    await _customer.AddorEdit(new Customer()
                    {
                    });


                }
                else
                {
                    var obj = db.Customers.Where(x => x.Id == cto.Id).ToList().FirstOrDefault();
                    if (obj.Id > 0)
                    {

                        obj.FirstName = cto.FirstName;
                        obj.LastName = cto.LastName;
                        obj.Address = cto.Address;
                        db.SaveChanges();
                    }
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