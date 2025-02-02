using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject
{
    internal class OrderDetailTest
    {
        public int OrderDetailID { get; set; }

        // Foreign Keys
        public int OrderID { get; set; }
        public int ProductID { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }

        // Navigation Properties
        public OrderTest Order { get; set; } = null!;
        public ProductTest Product { get; set; } = null!;

    }
}
