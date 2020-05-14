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

        // sales_agent_invoices.sql: Provide a query that shows the invoices associated with each sales agent.
        // The resultant table should include the Sales Agent's full name.

        [HttpGet("salesAgent/invoices")]
        public IActionResult GetSalesAgentsInvoices()
        {
            var repo = new EmployeeRepository();
            var employees = repo.GetSalesAgentsInvoices();

            if (!employees.Any())
            {
                return NotFound();
            }
            return Ok(employees);
        }
    }
}
