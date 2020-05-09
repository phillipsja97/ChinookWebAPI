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
    }
}
