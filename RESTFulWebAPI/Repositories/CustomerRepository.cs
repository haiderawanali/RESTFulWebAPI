using Microsoft.EntityFrameworkCore;
using RESTFulWebAPI.Data;
using RESTFulWebAPI.Models;

namespace RESTFulWebAPI.Repositories
{
    public class CustomerRepository : CustomerInterface
    {

        private readonly _DbContext _dbcontext;

        public CustomerRepository(_DbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _dbcontext.Customer.ToListAsync();
        }

        public async Task<Customer> GetByID(int id)
        {
            return await _dbcontext.Customer.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<bool> Insert(Customer ObjCustomer)
        {
            _dbcontext.Add(ObjCustomer);
            var customer = await _dbcontext.SaveChangesAsync();

            if (customer > 0)
                return true;
            else
                return false;
        }

        public async Task<bool> Update(Customer ObjCustomer)
        {
            var customer = await _dbcontext.Customer.FindAsync(ObjCustomer.Id);
            if (customer == null)
                return false;

            ObjCustomer.Name = customer.Name;            
            ObjCustomer.CustomerTypeId = customer.CustomerTypeId;
            ObjCustomer.Description = customer.Description;
            ObjCustomer.Address = customer.Address;
            ObjCustomer.City = customer.City;
            ObjCustomer.State = customer.State;
            ObjCustomer.Zip = customer.Zip;
            ObjCustomer.LastUpdated = customer.LastUpdated;

            var customerRes = await _dbcontext.SaveChangesAsync();

            if (customerRes > 0)
                return true;
            else
                return false;
        }

        public async Task<bool> Delete(int Id)
        {
            var customer = await _dbcontext.Customer.FindAsync(Id);
            _dbcontext.Customer.Remove(customer);
            var Result  = await _dbcontext.SaveChangesAsync();

            if (Result > 0)
                return true;
            else
                return false;
        }
    }
}
