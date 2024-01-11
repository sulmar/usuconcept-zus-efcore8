using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sakila.Domain.Model;

public partial class FilmCategory
{
    public int FilmId { get; set; }

    public byte CategoryId { get; set; }

    public DateTime LastUpdate { get; set; }

    public Category Category { get; set; } = null!;

    public Film Film { get; set; } = null!;
}
