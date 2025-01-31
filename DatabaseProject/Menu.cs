using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using DatabaseProject.Models;
using DatabaseProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace DatabaseProject
{
    internal class Menu
    {
        private readonly CustomerService _customerService;
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;

        public Menu(CustomerService customerService, ProductService productService, CategoryService categoryService)
        {
            _customerService = customerService;
            _productService = productService;
            _categoryService = categoryService;
        }

        public void ShowMenuNew()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine();
                // Create a selection prompt
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[green]Select an option:[/]")
                        .AddChoices(
                            "1. Search Customers",
                            "2. Get Customer By Email",
                            "3. Update Customer Email",
                            "4. View Categories",
                            "5. Search products by category",
                            "6. View products",
                            "7. View customers order summaries",
                            "8. Exit"
                        ));

                // Handle user selection
                switch (choice)
                {
                    case "1. Search Customers":
                        SearchCustomersByName();
                        break;
                    case "2. Get Customer By Email":
                        GetCustomerByEmail();
                        break;
                    case "3. Update Customer Email":
                        UpdateCustomerEmail();
                        break;
                    case "4. View Categories":
                        ViewCategories();
                        break;
                    case "5. Search products by category":
                        SearchProductsByCategory();
                        break;
                    case "6. View products":
                        ViewProductDetails();
                        break;
                    case "7. View customers order summaries":
                        DisplayCustomerOrderSummaries();
                        break;
                    case "8. Exit":
                        running = false;
                        AnsiConsole.MarkupLine("[red]Exiting...[/]");
                        break;
                    default:
                        AnsiConsole.MarkupLine("[red]Invalid choice, please try again.[/]");
                        break;
                }
            }
        }

        private void SearchCustomersByName()
        {
            Console.WriteLine("Enter name to search:");
            string keyword = Console.ReadLine();
            var customers = _customerService.SearchCustomersByName(keyword);
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.FirstName} {customer.LastName} - {customer.Email}");
            }
        }

        private void UpdateCustomerEmail()
        {
            Console.WriteLine("Enter customer ID:");
            int customerId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new email:");
            string newEmail = Console.ReadLine();
            _customerService.UpdateCustomerEmail(customerId, newEmail);
            Console.WriteLine("Email updated.");
        }

        private void GetCustomerByEmail()
        {
            Console.WriteLine("Enter email to search:");
            string email = Console.ReadLine();
            var customer = _customerService.GetCustomerByEmail(email);
            if (customer != null)
            {
                Console.WriteLine($"{customer.FirstName} {customer.LastName} - {customer.Email}");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }

        private void ViewCategories()
        {
            var categories = _categoryService.GetCategories();
            if (categories.Any())
            {
                Console.WriteLine($"Found {categories.Count} category(ies):");
                foreach (var c in categories)
                {
                    Console.WriteLine($"{c.CategoryId} - {c.CategoryName}");
                }
            }
            else
            {
                Console.WriteLine("No categories found.");
            }
        }

        private void SearchProductsByCategory()
        {
            Console.WriteLine("Enter Category ID:");
            if (int.TryParse(Console.ReadLine(), out int categoryId))
            {
                var products = _productService.GetProductsByCategory(categoryId);

                if (products.Count == 0)
                {
                    Console.WriteLine("No products found in this category.");
                }
                else
                {
                    Console.WriteLine($"Products in Category {categoryId}:");
                    foreach (var product in products)
                    {
                        Console.WriteLine($"{product.ProductName} - {product.Description} - {product.Price:C} - {product.StockQuantity} in stock");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid Category ID.");
            }
        }

        private void ViewProductDetails()
        {
            var products = _productService.GetProductDetails();

            foreach (var p in products)
            {
                Console.WriteLine($"{p.ProductId}: {p.ProductName} - {p.CategoryName} - {p.Price}");
            }
        }

        public static void DisplayCustomerOrderSummaries()
        {
            using (var context = new ApplicationDbContext())
            {
                var summaries = context.CustomerOrderSummaries.ToList();

                if (summaries.Count == 0)
                {
                    Console.WriteLine("\nNo customer order summaries found.");
                    return;
                }

                Console.WriteLine("\nCustomer Order Summaries:");
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine($"{"ID",-5} {"Customer Name",-25} {"Orders",-10} {"Products",-10} {"Total Spent",-10}");
                Console.WriteLine("-------------------------------------------------------------");

                foreach (var summary in summaries)
                {
                    Console.WriteLine($"{summary.CustomerId,-5} {summary.CustomerName,-25} {summary.TotalOrders,-10} {summary.TotalProducts,-10} {summary.TotalSpent:C}");
                }

                Console.WriteLine("-------------------------------------------------------------\n");
            }
        }

    }
}
