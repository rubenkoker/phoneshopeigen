using Microsoft.AspNetCore.Mvc;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Phoneshop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : Controller
    {
        private IBrandservice brandservice;

        public BrandController(IPhoneService phoneService)
        {
            this.brandservice = brandservice;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (brandservice.GetBrandById(id) != null)
            {
                return Ok(brandservice.GetBrandById(id));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task Create([FromBody] Brand value)
        {
            brandservice.InsertBrand(value);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await brandservice.RemoveBrand(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}