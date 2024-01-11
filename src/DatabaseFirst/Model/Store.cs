using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sakila.Domain.Model;

public partial class Store
{
    public int StoreId { get; set; }

    public byte ManagerStaffId { get; set; }

    public int AddressId { get; set; }

    public DateTime LastUpdate { get; set; }

    public Address Address { get; set; } = null!;

    public ObservableCollection<Customer> Customers { get; set; } = new ObservableCollection<Customer>();

    public ObservableCollection<Inventory> Inventories { get; set; } = new ObservableCollection<Inventory>();

    public Staff ManagerStaff { get; set; } = null!;

    public ObservableCollection<Staff> Staff { get; set; } = new ObservableCollection<Staff>();
}
