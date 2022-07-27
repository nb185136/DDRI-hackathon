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
        Services.ProductService _product = new Services.ProductService();

        [Route("addorupdate")]
        [HttpPost]
        public async Task<IHttpActionResult> AddorUpdate([FromBody] Product pto)
        {
            try
            {

                if (pto.ID == 0)
                {
                    var result = await _product.Create(pto);
                    return Ok(result);

                }
                else
                {
                    var result = await _product.Update(pto);
                    return Ok(result);

                }
                
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
            var result = await _product.Get();
            return Ok(result);
        }

        [Route("detailById")]
        [HttpGet]
        public async Task<IHttpActionResult> GetProductbyId(int id)
        {
            var result = await _product.GetProductById(id);
            return Ok(result);
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IHttpActionResult> delete(int id)
        {
            var result = await _product.Delete(id);
            return Ok(result);
        }

    }
}