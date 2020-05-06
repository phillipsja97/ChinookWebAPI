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

        // Provide a query showing only the Employees who are Sales Agents.

       



    }
}
