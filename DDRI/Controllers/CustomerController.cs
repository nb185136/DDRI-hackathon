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
        Services.CustomerService _customer = new Services.CustomerService();

        [Route("addorUpdate")]
        [HttpPost]
        public async Task<IHttpActionResult> AddorEdit(Customer cto)
        {
            try
            {

                if (cto.Id == 0)
                {
                    await _customer.Add(new Customer()
                    {
                    });


                }
                else
                {
                    await _customer.Edit(new Customer()
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
            await _customer.Get();
            return Ok();
        }

        [Route("detailById")]
        [HttpGet]
        public async Task<IHttpActionResult> GetCustomerbyId(int id)
        {
            await _customer.GetCustomerById(id);
            return Ok();
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IHttpActionResult> delete(int id)
        {
            await _customer.Delete(id);
            return Ok();
        }

    }
}