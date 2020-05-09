using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookWebAPI.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string Country { get; set; }
        public string BillingPostalCode { get; set; }
        public int Total { get; set; }
    }

    public class InvoiceTotalFromCountry
    {
        public string Country { get; set; }
        public decimal TotalSales { get; set; }
    }

    public class InvoiceWithCustomerAndTrackInfo
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal InvoiceTotal { get; set; }
        public string FullName { get; set; }
        public IEnumerable<int> Tracks { get; set; }
    }

    public class InvoiceTrack
    {
        public int TrackId { get; set; }
        public int InvoiceId { get; set; }
    }
}
