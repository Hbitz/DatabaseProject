using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using System;
using Microsoft.EntityFrameworkCore;
using DatabaseProject.Models;
using DatabaseProject.Services;


namespace DatabaseProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // new new new
            // Set up Dependency Injection (DI) container and configure services
            var builder = Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    // Set the minimum level for all loggers
                    logging.SetMinimumLevel(LogLevel.Warning); // Only show warnings and errors
                })
                .ConfigureServices((context, services) =>
                {
                    // Register ApplicationDbContext with connection string from appsettings.json
                    services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));

                    // Register CustomerService without interface
                    services.AddScoped<CustomerService>();
                    services.AddScoped<ProductService>();
                    services.AddScoped<CategoryService>();

                    // Register other services like Menu, if necessary
                    services.AddSingleton<Menu>();  // Ensure Menu is registered to be used in DI
                });

            // Build the app and get the services from DI container
            var app = builder.Build();

            // Get an instance of CustomerService and Menu from DI container
            var customerService = app.Services.GetRequiredService<CustomerService>();
            // Same with rest
            var productService = app.Services.GetRequiredService<ProductService>();
            var categoryService = app.Services.GetRequiredService<CategoryService>();
            var menu = app.Services.GetRequiredService<Menu>(); 

            // Start the menu to show options
            menu.ShowMenuNew();

            // Run the application
            app.Run();

        }
    }
}
