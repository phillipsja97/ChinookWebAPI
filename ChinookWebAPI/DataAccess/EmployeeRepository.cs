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

        public List<SalesAgentsInvoices> GetSalesAgentsInvoices()
        {
            var sql = @"
                        select CONCAT(Employee.FirstName, Employee.LastName) as FullName, Employee.EmployeeId as AgentId
                            from Employee
                               where Employee.Title like 'Sales Support%'";
                
            var invoiceReps = @"select invoice.invoiceId, Customer.SupportRepId 
                                from Invoice
                                    join Customer on Invoice.InvoiceId = Customer.CustomerId";

            using (var db = new SqlConnection(ConnectionString))
            {
                var result = db.Query<SalesAgentsInvoices>(sql).ToList();
                var theInvoices = db.Query<InvoicesForAgents>(invoiceReps);

                foreach (var info in result)
                {
                    info.Invoices = theInvoices.Where(li => li.SupportRepId == info.AgentId).Select(x => x.InvoiceId);
                }
                return result;
            }
        }


    }
}
