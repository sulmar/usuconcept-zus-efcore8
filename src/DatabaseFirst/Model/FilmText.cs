using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sakila.Domain.Model;

public partial class FilmText
{
    public short FilmId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }
}
