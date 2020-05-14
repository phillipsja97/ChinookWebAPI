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
    [Route("api/customers")]
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

        // brazil_customers_invoices.sql: Provide a query showing the Invoices of customers who are from Brazil.
        // The resultant table should show the customer's full name, Invoice ID, Date of the invoice and billing country.

        [HttpGet("invoice/{country}")]
        public IActionResult GetCustomersByBillingCountry(string country)
        {
            var repo = new CustomerRepository();
            var customers = repo.GetCustomersAndInvoiceByCountry(country);

            if (!customers.Any())
            {
                return NotFound();
            }
            return Ok(customers);
        }
    }
}
