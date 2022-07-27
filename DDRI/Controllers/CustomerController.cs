﻿using DDRI.DBObjects;
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
        Services.CustomerService _customer = new Services.CustomerService();

        [Route("addorUpdate")]
        [HttpPost]
        public async Task<IHttpActionResult> AddorEdit([FromBody] Customer cto)
        {
            try
            {

                if (cto.Id == 0)
                {
                    var result = await _customer.Add(cto);
                    return Ok(result);

                }
                else
                {
                   var result = await _customer.Edit(cto);
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
            var result = await _customer.Get();
            return Ok(result);
        }

        [Route("detailById")]
        [HttpGet]
        public async Task<IHttpActionResult> GetCustomerbyId(int id)
        {
            var result = await _customer.GetCustomerById(id);
            return Ok(result);
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IHttpActionResult> delete(int id)
        {
            var result = await _customer.Delete(id);
            return Ok(result);
        }

    }
}