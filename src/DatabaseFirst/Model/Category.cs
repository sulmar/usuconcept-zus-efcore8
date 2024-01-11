using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sakila.Domain.Model;

public partial class Category
{
    public byte CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime LastUpdate { get; set; }

    public ObservableCollection<FilmCategory> FilmCategories { get; set; } = new ObservableCollection<FilmCategory>();
}
