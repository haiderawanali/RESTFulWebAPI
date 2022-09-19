using RESTFulWebAPI.Models;

namespace RESTFulWebAPI.Repositories
{
    public interface CustomerInterface
    {
        Task<List<Customer>> GetAll();

        Task<Customer> GetByID(int id);

        Task<bool> Insert(Customer ObjCustomer);

        Task<bool> Update(Customer ObjCustomer);

        Task<bool> Delete(int Id);
    }
}
