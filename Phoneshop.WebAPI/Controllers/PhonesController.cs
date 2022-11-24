using Microsoft.AspNetCore.Mvc;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Phoneshop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonesController : ControllerBase
    {

        private IPhoneService phoneService;
        private readonly IRepository<Phone> _repository;
        static ServiceCollection phoneservices = new();
        //ConfigureServices(phoneservices);
        ServiceProvider serviceProvider = phoneservices.BuildServiceProvider();
        //brandservice = serviceProvider.GetRequiredService<IBrandservice>();
        // _logger = serviceProvider.GetRequiredService<ILogger>();
        public PhonesController(IPhoneService phoneService)
        {


            this.phoneService = phoneService;
        }

        //ConfigureServices(phoneservices);

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(phoneService.GetAllPhones());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (phoneService.GetPhoneById(id) != null)
            {
                return Ok(phoneService.GetPhoneById(id));
            }
            return NotFound();
        }
        // GET api/<ValuesController>/5
        [HttpGet("search/{search}")]
        public IActionResult GetPhones(string search)
        {
            if (String.IsNullOrEmpty(search))
            {
                return Ok(phoneService.GetAllPhones());
            }
            return Ok(phoneService.Search(search));

        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Create([FromBody] Phone value)
        {
            phoneService.AddPhone(value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }

}
