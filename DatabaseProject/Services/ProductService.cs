using DatabaseProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Services
{
    internal class ProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            var products = _context.Products
                .FromSqlInterpolated($"EXEC GetProductsByCategory @CategoryID = {categoryId}")
                .ToList();
            return products;
        }
        public List<ProductView> GetProductDetails()
        {
            return _context.ProductViews.ToList();
        }
    }
}
