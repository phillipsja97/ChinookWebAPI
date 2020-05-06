using System.Collections.Generic;
using ChinookWebAPI.Models;
using Microsoft.Data.SqlClient;

namespace ChinookWebAPI.DataAccess
{
    public class CustomerRepository
    {
        const string ConnectionString = "Server = localhost; Database = Chinook; Trusted_Connection = True;";
        public List<Customer> GetByCountry(string country)
        {
              var sql = @"
                        select FirstName, LastName, CustomerId, Country
                          from Customer
                              where Customer.Country = @Country";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("Country", country);

                var reader = cmd.ExecuteReader();
                var customers = new List<Customer>();
                while (reader.Read())
                {
                    var customer = new Customer
                    {
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        CustomerId = (int)reader["CustomerId"],
                        Country = (string)reader["Country"]
                    };

                    customers.Add(customer);
                }
                return customers;
            }
        }

    }
}
