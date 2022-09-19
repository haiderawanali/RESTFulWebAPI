using Microsoft.AspNetCore.Mvc;
using RESTFulWebAPI.Models;
using RESTFulWebAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTFulWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerInterface _CustomerInterface;

        public CustomerController(CustomerInterface customerInterface)
        {
            _CustomerInterface = customerInterface;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Index()
        {
            return await _CustomerInterface.GetAll();
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<ActionResult> AddCustomer(Customer customer)
        {
            var res =  await _CustomerInterface.Insert(customer);

            return Ok(res);

        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomerAsync(Customer customer)
        {
            var res = await _CustomerInterface.Update(customer);

            return Ok(res);

        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var res = await _CustomerInterface.Delete(id);

            return Ok(res);
        }
    }
}
