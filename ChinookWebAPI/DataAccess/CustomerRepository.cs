using System.Collections.Generic;
using ChinookWebAPI.Models;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Linq;

namespace ChinookWebAPI.DataAccess
{
    public class CustomerRepository
    {
        const string ConnectionString = "Server = localhost; Database = Chinook; Trusted_Connection = True;";
        
        // show all customers in a certain country
        public List<Customer> GetByCountry(string country)
        {
              var sql = @"
                        select FirstName, LastName, CustomerId, Country
                          from Customer
                              where Customer.Country = @Country";

            using (var db = new SqlConnection(ConnectionString))
            {

                var parameter = new { Country = country };
                var customers = db.Query<Customer>(sql, parameter).ToList();
                return customers;

            }
        }

        public List<CustomersByCountry> GetCustomersAndInvoiceByCountry(string country)
        {
            var sql = @"
                        select CONCAT(Customer.firstName, ' ', Customer.LastName) as FullName, Invoice.InvoiceId as InvoiceId, Invoice.InvoiceDate as InvoiceDate, Invoice.BillingCountry as BillingCountry
                            from Customer
	                            join Invoice
	                                on Customer.CustomerId = Invoice.CustomerId
	                                    where Invoice.BillingCountry = @Country";

            using (var db = new SqlConnection(ConnectionString))
            {
                var parameters = new { Country = country };
                var result = db.Query<CustomersByCountry>(sql, parameters).ToList();

                return result;
            }
        }
    }
}
