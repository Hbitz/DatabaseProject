using DatabaseProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Services
{
    internal class CustomerService 
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Customer> SearchCustomersByName(string keyword)
        {
            // Call the stored procedure
            var customers = _context.Customers
                .FromSqlInterpolated($"EXEC SearchCustomersByName @Keyword = {keyword}")
                .ToList();

            return customers;
        }
        // Stored procedure to get a customer by email. Only includes name and email, nothing else
        public Customer GetCustomerByEmail(string email)
        {
            return _context.Customers
                .FromSqlInterpolated($"EXEC GetCustomerByEmail {email}")
                .AsEnumerable()
                .FirstOrDefault(); // Assuming the email is unique, so only one customer will be returned
        }

        // Stored procedure to update a customer's email
        public void UpdateCustomerEmail(int customerId, string newEmail)
        {
            _context.Database.ExecuteSqlInterpolated($"EXEC UpdateCustomerEmail {customerId}, {newEmail}");
        }
    }
}
