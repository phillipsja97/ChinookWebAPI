using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChinookWebAPI.DataAccess;

namespace ChinookWebAPI.Controllers
{
    [Route("api/invoices")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        // GET: api/Invoice
        [HttpGet("total/{year}")]
        public IActionResult GetInvoiceTotals(int year)
        {
            var repo = new InvoiceRepository();
            var invoices = repo.GetInvoiceTotalForYear(year);
            return Ok(invoices);
        }
    }
}
