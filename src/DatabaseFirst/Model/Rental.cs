using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sakila.Domain.Model;

public partial class Rental
{
    public int RentalId { get; set; }

    public DateTime RentalDate { get; set; }

    public int InventoryId { get; set; }

    public int CustomerId { get; set; }

    public DateTime? ReturnDate { get; set; }

    public byte StaffId { get; set; }

    public DateTime LastUpdate { get; set; }

    public Customer Customer { get; set; } = null!;

    public Inventory Inventory { get; set; } = null!;

    public ObservableCollection<Payment> Payments { get; set; } = new ObservableCollection<Payment>();

    public Staff Staff { get; set; } = null!;
}
