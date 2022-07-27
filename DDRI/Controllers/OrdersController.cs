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
    //[Route("api/customer/[controller]")]
    [RoutePrefix("api/Orders")]
    public class OrdersController : ApiController
    {
        public OrderService _orderService = null;
        public OrdersController()
        {
            _orderService = new OrderService();
        }
        //
        [Route("Customer/{customerId}/Create")]
        [HttpPost]
        public async Task<IHttpActionResult> Create(int customerId, [FromBody] OrderRequestModel items)
        {
            try
            {
                var result = await _orderService.Create(customerId, items);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok((int)HttpStatusCode.InternalServerError);
            }

        }

        [HttpGet]
        public async Task<IHttpActionResult> GetOrders()
        {
            try
            {
                var result = await _orderService.GetOrders();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok((int)HttpStatusCode.InternalServerError);
            }

        }

        [HttpGet]
        [Route("Customer/{customerId}")]
        public async Task<IHttpActionResult> GetOrdersbyCustomerId(int customerId)
        {
            try
            {
                var result = await _orderService.GetOrderbyCustomerId(customerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok((int)HttpStatusCode.InternalServerError);
            }

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetOrderbyId(int id)
        {
            try
            {
                var result = await _orderService.GetOrderbyId(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok((int)HttpStatusCode.InternalServerError);
            }

        }

        [HttpGet]
        [Route("{id}/DeliveredOn/{deliveredOn}")]
        public async Task<IHttpActionResult> AddRewardtoDelayedOrder(int orderId, int deliveredInMins)
        {
            try
            {
                var result = await _orderService.AddRewardtoOrder(orderId, deliveredInMins);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok((int)HttpStatusCode.InternalServerError);
            }

        }
    }
}
