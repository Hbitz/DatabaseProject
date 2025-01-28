using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using DatabaseProject.Models;
using DatabaseProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("1. Search Customers");
            Console.WriteLine("2. Get Customer By Email");
            Console.WriteLine("3. Update Customer Email");
            Console.WriteLine("4. View Categories");
            Console.WriteLine("5. Search products by category");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    SearchCustomersByName();
                    break;
                case 2:
                    UpdateCustomerEmail();
                    break;
                case 3:
                    GetCustomerByEmail();
                    break;
                case 4: 
                    ViewCategories();
                    break;
                case 5:
                    SearchProductsByCategory();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
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
    }
}
