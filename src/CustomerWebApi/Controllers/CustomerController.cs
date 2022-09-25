using CustomerDatalayer.Entities;
using CustomerDatalayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private CustomerRepository CustomerRepository = new();

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            return Ok(CustomerRepository.ReadAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Customer>>> GetCustomer(int id)
        {
            return Ok(CustomerRepository.Read(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<Customer>>> AddCustomer(Customer customer)
        {
            return Ok(CustomerRepository.Create(customer));
        }

        [HttpPut]
        public async Task<ActionResult<List<Customer>>> UpdateCustomer(Customer customer)
        {
            return Ok(CustomerRepository.Update(customer));
        }

        [HttpDelete]
        public async Task<ActionResult<List<Customer>>> DeleteCustomer(int id)
        {
            return Ok(CustomerRepository.Delete(id));
        }
    }
}
