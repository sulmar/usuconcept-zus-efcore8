using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sakila.Domain.Model;

public partial class City
{
    public int CityId { get; set; }

    public string City1 { get; set; } = null!;

    public short CountryId { get; set; }

    public DateTime LastUpdate { get; set; }

    public ObservableCollection<Address> Addresses { get; set; } = new ObservableCollection<Address>();

    public Country Country { get; set; } = null!;
}
