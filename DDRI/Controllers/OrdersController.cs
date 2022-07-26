using DDRI.DBObjects;
using DDRI.Models;
using DDRI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace DDRI.Controllers
{
    [Route("customer/{controller}")]
    public class OrdersController : ApiController
    {
        public OrderService _orderService = null;
        public OrdersController()
        {
            _orderService = new OrderService();
        }
        [Route("{customerId}/create")]
        [HttpPost]
        public async Task<IHttpActionResult> Create(int customerId, [FromBody]IEnumerable<CartItems> items)
        {
            try
            {
                var result = await _orderService.Create(customerId, items.ToList());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok((int)HttpStatusCode.InternalServerError);
            }

        }
    }
}
