using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using DatabaseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject
{
    internal class Menu
    {
        private readonly ApplicationDbContext _context;

        public Menu()
        {
            string _projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;


            var configuration = new ConfigurationBuilder()
                //.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .SetBasePath(_projectPath)
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            _context = new ApplicationDbContext(optionsBuilder.Options);
        }

        public void ShowMainMenu()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("1. Manage categories");
                Console.WriteLine("2. Manage Customers");
                Console.WriteLine("3. Manage Products");
                Console.WriteLine("4. Manage Orders");
                Console.WriteLine("5(NEW). - Test context and get first customer");

                Console.WriteLine("Choose an option");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Not yet implemented
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        ViewFirstCustomer();
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again");
                        break;
                }
            }

            if (running)
            {
                Console.WriteLine("\nPress any key to go back to main menu");
                Console.ReadKey();
            }
        }

        public void ViewFirstCustomer()
        {
            var customer = _context.Customers.FirstOrDefault();
            if (customer != null)
            {
                Console.WriteLine($"Customer ID: {customer.CustomerId}");
                Console.WriteLine($"First Name: {customer.FirstName}");
                Console.WriteLine($"Last Name: {customer.LastName}");
                Console.WriteLine($"Email: {customer.Email}");
                Console.WriteLine($"Address: {customer.Address}");
                Console.WriteLine($"City: {customer.City}");
                Console.WriteLine($"Postal Code: {customer.PostalCode}");
                Console.WriteLine($"Register Date: {customer.RegisterDate}");
            }
            else
            {
                Console.WriteLine("No customers found.");
            }

            Console.WriteLine("\nPress any key to return to the menu.");
            Console.ReadKey();
        }
    }
}
