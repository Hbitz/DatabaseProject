using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject
{
    internal class OrderTest
    {
        public int OrderID { get; set; }

        // Foreign Key
        public int CustomerID { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }

        // Navigation Properties
        public CustomerTest Customer { get; set; } = null!;
        public ICollection<OrderDetailTest> OrderDetails { get; set; } = new List<OrderDetailTest>();
        public ICollection<PaymentTest> Payments { get; set; } = new List<PaymentTest>();

    }
}
