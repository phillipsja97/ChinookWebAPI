using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ChinookWebAPI.Models;
using Dapper;

namespace ChinookWebAPI.DataAccess
{
    public class EmployeeRepository
    {
        const string ConnectionString = "Server = localhost; Database = Chinook; Trusted_Connection = True;";

        public List<Employee> GetEmployeeByTitle(string title)
        {
            var sql = @"select *
                        from Employee
                          where Employee.Title like @title";

            using (var db = new SqlConnection(ConnectionString))
            {
                var parameters = new { Title = title };
                var employees = db.Query<Employee>(sql, parameters).ToList();
                return employees;
            }
        }
    }
}
