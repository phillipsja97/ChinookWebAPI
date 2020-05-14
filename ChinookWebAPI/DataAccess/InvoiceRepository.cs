using ChinookWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;

namespace ChinookWebAPI.DataAccess
{
    public class InvoiceRepository

    {
        const string ConnectionString = "Server = localhost; Database = Chinook; Trusted_Connection = True;";
        public List<Invoice> GetInvoiceTotalForYear(int year)
        {
            var sql = @"
                SELECT * 
                    FROM Invoice 
                        WHERE Year(Invoice.InvoiceDate) = @year";

            using (var db = new SqlConnection(ConnectionString))
            {
                var parameters = new { Year = year };
                var invoices = db.Query<Invoice>(sql, parameters).ToList();
                return invoices;
            }
        }

        public List<InvoiceTotalFromCountry> GetInvoicetotalPerCountry()
        {
            var sql = @"
                select Invoice.BillingCountry as Country, Sum(Invoice.Total) as TotalSales
                    from Invoice
                        group by Invoice.BillingCountry";

            using (var db = new SqlConnection(ConnectionString))
            {
                var invoices = db.Query<InvoiceTotalFromCountry>(sql).ToList();
                return invoices;
            }
        }

        public IEnumerable<InvoiceWithCustomerAndTrackInfo> GetInnvoicesWithCustomersInfo()
        {
            var sql = @" 
                select i.InvoiceId, c.CustomerId, i.InvoiceDate, i.Total as InvoiceTotal, c.FirstName + ' ' + c.LastName as FullName
                    from Invoice i
                        join customer c
                            on i.customerId = c.customerId
                       ";
            var invoiceLineQuery = "select trackId, invoiceId from InvoiceLine";

            using (var db = new SqlConnection(ConnectionString))
            {
                var result = db.Query<InvoiceWithCustomerAndTrackInfo>(sql).ToList();
                var invoiceLines = db.Query<InvoiceTrack>(invoiceLineQuery);

                foreach (var info in result)
                {
                    info.Tracks = invoiceLines.Where(il => il.InvoiceId == info.InvoiceId).Select(il => il.TrackId);
                }
                return result;
            }

        }


    }
}

