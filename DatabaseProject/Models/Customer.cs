using System;
using System.Collections.Generic;

namespace DatabaseProject.Models;

public partial class Customer
{
    public int CustomerId { get; set; } //changed CustomerId to CustomerID

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Address { get; set; }

    public string City { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public DateOnly RegisterDate { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
