using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sakila.Domain.Model;

public partial class Country
{
    public short CountryId { get; set; }

    public string Country1 { get; set; } = null!;

    public DateTime? LastUpdate { get; set; }

    public ObservableCollection<City> Cities { get; set; } = new ObservableCollection<City>();
}
