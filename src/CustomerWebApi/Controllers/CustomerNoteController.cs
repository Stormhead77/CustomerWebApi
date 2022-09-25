using CustomerDatalayer.Entities;
using CustomerDatalayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWebApi.Controllers
{
    public class CustomerNoteController : Controller
    {
        private CustomerNoteRepository CustomerNoteRepository = new();

        [HttpGet("{id}")]
        public async Task<ActionResult<List<CustomerNote>>> GetCustomerNote(int id)
        {
            return Ok(CustomerNoteRepository.Read(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<CustomerNote>>> AddCustomerNote(CustomerNote customerNote)
        {
            return Ok(CustomerNoteRepository.Create(customerNote));
        }

        [HttpPut]
        public async Task<ActionResult<List<CustomerNote>>> UpdateCustomerNote(CustomerNote customerNote)
        {
            return Ok(CustomerNoteRepository.Update(customerNote));
        }

        [HttpDelete]
        public async Task<ActionResult<List<CustomerNote>>> DeleteCustomerNote(int id)
        {
            return Ok(CustomerNoteRepository.Delete(id));
        }
    }
}
