using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sakila.Domain.Model;

public partial class Staff
{
    public byte StaffId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int AddressId { get; set; }

    public byte[]? Picture { get; set; }

    public string? Email { get; set; }

    public int StoreId { get; set; }

    public bool Active { get; set; }

    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public DateTime LastUpdate { get; set; }

    public Address Address { get; set; } = null!;

    public ObservableCollection<Payment> Payments { get; set; } = new ObservableCollection<Payment>();

    public ObservableCollection<Rental> Rentals { get; set; } = new ObservableCollection<Rental>();

    public Store Store { get; set; } = null!;

    public Store? StoreNavigation { get; set; }
}
