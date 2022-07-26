using System.Threading.Tasks;

namespace DDRI.Services.interfaces
{
    public interface ICustomer
    {
        Task<DBObjects.Customer> AddorEdit(DBObjects.Customer customer);

        Task<DBObjects.Customer> Delete(int id);

        Task<DBObjects.Customer> GetCustomerById(int id);

        Task<DBObjects.Customer> Get();
    }
}