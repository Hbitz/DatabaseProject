using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject
{
    internal class CustomerTest
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;

        //navigation property
        public ICollection<OrderTest> Orders { get; set; } = new List<OrderTest>();
    }
}
