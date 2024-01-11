using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sakila.Domain.Model;

public partial class Inventory
{
    public int InventoryId { get; set; }

    public int FilmId { get; set; }

    public int StoreId { get; set; }

    public DateTime LastUpdate { get; set; }

    public Film Film { get; set; } = null!;

    public ObservableCollection<Rental> Rentals { get; set; } = new ObservableCollection<Rental>();

    public Store Store { get; set; } = null!;
}
