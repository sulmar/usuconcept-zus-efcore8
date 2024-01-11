using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sakila.Domain.Model;

public partial class SalesByFilmCategory
{
    public string Category { get; set; } = null!;

    public decimal? TotalSales { get; set; }
}
