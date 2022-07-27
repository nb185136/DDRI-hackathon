using DDRI.DBObjects;
using DDRI.Models;
using DDRI.Services.interfaces;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace DDRI.Services
{
    public class CustomerService
    {
        private DDRIEntities _db = null;
        string _adminUsers = ConfigurationManager.AppSettings["SysAdmin"];
        public CustomerService()
        {
            _db = new DDRIEntities();
        }

        public CustomerResponseModel Login(DBObjects.Customer customer)
        {
            var customerDetails = _db.Customers.Where(x => x.Email.Equals(customer.Email) && x.Password.Equals(customer.Password)).FirstOrDefault();
            if (customerDetails != null)
            {
                return new CustomerResponseModel()
                {
                    isAdmin = customerDetails.Email.ToLower() == _adminUsers.ToLower(),
                    Email = customerDetails.Email,
                    Address = customerDetails.Address,
                    City = customerDetails.City,
                    FirstName = customerDetails.FirstName,
                    LastName = customerDetails.LastName,
                    Phone = customerDetails.Phone,
                    RewardPoints = customerDetails.RewardPoints,
                    State = customerDetails.State,
                    UserName = customerDetails.UserName,
                    Password = customerDetails.Password
                };
            }
            else
            {
                return null;
            }
        }
        public async Task<DBObjects.Customer> Add(DBObjects.Customer customer)
        {
            Customer c = new Customer();
            c.Id = customer.Id;
            c.FirstName = customer.FirstName;
            c.LastName = customer.LastName;
            c.State = customer.State;
            c.City = customer.City;
            c.Address = customer.Address;
            c.Email = customer.Email;
            c.Phone = customer.Phone;
            c.CreatedOn = System.DateTime.Now;
            c.UpdatedOn = System.DateTime.Now;
            c.IsDeleted = false;
            c.UserName = customer.UserName;
            c.Password = customer.Password;
            c.RewardPoints = customer.RewardPoints;
            _db.Customers.Add(c);
            _db.SaveChanges();
            return c;
        }

        public async Task<DBObjects.Customer> Edit(DBObjects.Customer customer)
        {
            var obj = _db.Customers.Where(x => x.Id == customer.Id).ToList().FirstOrDefault();
            if (obj.Id > 0)
            {

                obj.FirstName = customer.FirstName;
                obj.LastName = customer.LastName;
                obj.Address = customer.Address;
                _db.SaveChanges();
            }
            return obj;
        }

        public async Task<DBObjects.Customer> Delete(int id)
        {
            var obj = _db.Customers.Where(x => x.Id == id).ToList().FirstOrDefault();
            _db.Customers.Remove(obj);
            _db.SaveChanges();
            return obj;
        }

        public async Task<IList<DBObjects.Customer>> Get()
        {
            var a = _db.Customers.ToList();
            return a;
        }

        public async Task<DBObjects.Customer> GetCustomerById(int id)
        {
            var obj = _db.Customers.Where(x => x.Id == id).ToList().FirstOrDefault();
            return obj;
        }
    }
}