﻿using Microsoft.AspNetCore.Mvc;
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

        public PhonesController(IPhoneService phoneService)
        {
            this.phoneService = phoneService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(phoneService.GetAllPhones());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (phoneService.GetPhoneById(id) != null)
            {
                return Ok(phoneService.GetPhoneById(id));
            }
            return NotFound();
        }

        [HttpGet("search/{search}")]
        public IActionResult GetPhones(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return Ok(phoneService.GetAllPhones());
            }
            return Ok(phoneService.Search(search));
        }

        [HttpPost]
        public void Create([FromBody] Phone value)
        {
            phoneService.AddPhone(value);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (phoneService.RemovePhone(id))
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