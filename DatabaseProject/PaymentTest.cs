using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject
{
    internal class PaymentTest
    {
        public int PaymentID { get; set; }

        // Foreign Key
        public int OrderID { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;

        // Navigation Property
        public OrderTest Order { get; set; } = null!;

    }
}
