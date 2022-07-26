using DDRI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDRI.Controllers
{
    [RoutePrefix("api/Customer")]
    public class CustomerController : Controller
    {
        DDRIEntities db = new DDRIEntities();

        [Route("addorUpdate")]
        [HttpPost]
        public object addorUpdate(CustomerDto cto)
        {
            try
            {
                if (cto.Id == 0)
                {
                    Customer c = new Customer();
                    c.FirstName = cto.FirstName;
                    c.LastName = cto.LastName;
                    c.State = cto.State;
                    c.City = cto.City;
                    c.Address = cto.Address;
                    c.Email = cto.Email;
                    c.Phone = cto.Phone;
                    c.CreatedOn = System.DateTime.Now;
                    c.UpdatedOn = System.DateTime.Now;
                    c.IsDeleted = false;
                    c.UserName = cto.UserName;
                    c.Password = cto.Password;
                    c.RewardPoints = cto.RewardPoints;
                    db.Customers.Add(c);
                    db.SaveChanges();
                    return new Response
                    {
                        Status = "Success",
                        Message = "Data Successfully"
                    };
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
                        return new Response
                        {
                            Status = "Updated",
                            Message = "Updated Successfully"
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return new Response
            {
                Status = "Error",
                Message = "Data not insert"
            };

        }

        [Route("details")]
        [HttpGet]
        public object details()
        {

            var a = db.Customers.ToList();
            return a;
        }

        [Route("detailById")]
        [HttpGet]
        public object detailById(int id)
        {
            var obj = db.Customers.Where(x => x.Id == id).ToList().FirstOrDefault();
            return obj;
        }

        [Route("delete")]
        [HttpDelete]
        public object delete(int id)
        {
            var obj = db.Customers.Where(x => x.Id == id).ToList().FirstOrDefault();
            db.Customers.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }

    }
}