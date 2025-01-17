﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;
using ValidationExtensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Phoneshop.WebAPI.Controllers
{
    [EnableCors]
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
        public async Task<IActionResult> Get()
        {
            var phonelist = await phoneService.GetAllPhones();

            foreach (var phone in phonelist)
            {
                var maillist = phone.Description.ExtractEmails();
                if (maillist.Count > 0)
                {
                    foreach (var mail in maillist)
                    {
                        phone.Description = phone.Description.Replace(mail, "*******");
                    }
                }
            }
            return Ok(phonelist);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (phoneService.GetPhoneById(id) != null)
            {
                return Ok(phoneService.GetPhoneById(id));
            }
            return NotFound();
        }

        [HttpGet("search/{search}")]
        public async Task<IActionResult> GetPhones(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return Ok(phoneService.GetAllPhones());
            }
            return Ok(phoneService.Search(search));
        }

        [HttpPost]
        public async Task Create([FromBody] Phone value)
        {
            phoneService.AddPhone(value);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await phoneService.RemovePhone(id))
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