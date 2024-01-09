using System;
using System.Collections.Generic;

namespace TrackingChanges.Model;

public partial class SalesByStore
{
    public int StoreId { get; set; }

    public string Store { get; set; } = null!;

    public string Manager { get; set; } = null!;

    public decimal? TotalSales { get; set; }
}
