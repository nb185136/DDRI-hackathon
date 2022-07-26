using DDRI.DBObjects;
using DDRI.Services.interfaces;
using System.Threading.Tasks;

namespace DDRI.Services
{
    public class Customer
    {
        private DDRIEntities _db = null;
        public Customer()
        {
            _db = new DDRIEntities();
        }
        public async Task<DBObjects.Customer> AddorEdit(DBObjects.Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public async Task<DBObjects.Customer> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<DBObjects.Customer> Get()
        {
            throw new System.NotImplementedException();
        }

        public async Task<DBObjects.Customer> GetCustomerById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}