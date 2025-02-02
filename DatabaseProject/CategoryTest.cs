using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject
{
    internal class CategoryTest
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        // Navigation Property
        public ICollection<ProductTest> Products { get; set; } = new List<ProductTest>();
    }
}
