using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject
{
    internal class ProductTest
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        // Foreign Key
        public int CategoryID { get; set; }

        // Navigation Properties
        public CategoryTest Category { get; set; } = null!;
        public ICollection<OrderDetailTest> OrderDetails { get; set; } = new List<OrderDetailTest>();

    }
}
