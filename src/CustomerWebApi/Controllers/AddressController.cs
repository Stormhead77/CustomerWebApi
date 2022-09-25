using CustomerDatalayer.Entities;
using CustomerDatalayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : Controller
    {
        private AddressRepository AddressRepository = new();

        [HttpGet]
        public async Task<ActionResult<List<Address>>> GetAddresses()
        {
            return Ok(AddressRepository.ReadAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Address>>> GetAddress(int id)
        {
            return Ok(AddressRepository.Read(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<Address>>> AddAddress(Address customer)
        {
            return Ok(AddressRepository.Create(customer));
        }

        [HttpPut]
        public async Task<ActionResult<List<Address>>> UpdateAddress(Address customer)
        {
            return Ok(AddressRepository.Update(customer));
        }

        [HttpDelete]
        public async Task<ActionResult<List<Address>>> DeleteAddress(int id)
        {
            return Ok(AddressRepository.Delete(id));
        }
    }
}
