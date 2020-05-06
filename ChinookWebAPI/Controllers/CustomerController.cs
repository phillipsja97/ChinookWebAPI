using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChinookWebAPI.DataAccess;
using ChinookWebAPI.Models;

namespace ChinookWebAPI.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/Customer/brazil
        [HttpGet("{country}")]
        public IActionResult GetByCountry(string country)
        {
            var repo = new CustomerRepository();
            var customers = repo.GetByCountry(country);

            if (!customers.Any())
            {
                return NotFound();
            }
            return Ok(customers);
        }
    }
}
