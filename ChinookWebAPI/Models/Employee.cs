﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookWebAPI.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string ReportsTo { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
    }

    public class SalesAgentsInvoices
    {
        public string FullName { get; set; }
        public int AgentId { get; set; }
        public IEnumerable<int> Invoices { get; set; }
    }

    public class InvoicesForAgents
    {
        public int InvoiceId { get; set; }
        public int SupportRepId { get; set; }
    }
}