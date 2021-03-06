﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookWebAPI.Models
{
    public class Customer
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public int CustomerId { get; internal set; }
        public string Country { get; internal set; }
    }

    public class CustomersByCountry
    {
        public string FullName { get; set; }
        public int InvoiceId { get; set; }
        public string InvoiceDate { get; set; }
        public string BillingCountry { get; set; }
    }
}
