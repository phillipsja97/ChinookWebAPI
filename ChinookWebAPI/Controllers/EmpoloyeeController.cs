using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChinookWebAPI.DataAccess;

namespace ChinookWebAPI.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmpoloyeeController : ControllerBase
    {
        // GET: api/Empoloyee
        [HttpGet("{title}")]
        public IActionResult GetEmployeesByTitle(string title)
        {
            var repo = new EmployeeRepository();
            var employees = repo.GetEmployeeByTitle(title);

            if (!employees.Any())
            {
                return NotFound();
            }
            return Ok(employees);
        }
    }
}
