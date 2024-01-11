using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sakila.Domain.Model;

public partial class Address
{
    public int AddressId { get; set; }

    public string Address1 { get; set; } = null!;

    public string? Address2 { get; set; }

    public string District { get; set; } = null!;

    public int CityId { get; set; }

    public string? PostalCode { get; set; }

    public string Phone { get; set; } = null!;

    public DateTime LastUpdate { get; set; }

    public City City { get; set; } = null!;

    public ObservableCollection<Customer> Customers { get; set; } = new ObservableCollection<Customer>();

    public ObservableCollection<Staff> Staff { get; set; } = new ObservableCollection<Staff>();

    public ObservableCollection<Store> Stores { get; set; } = new ObservableCollection<Store>();
}
