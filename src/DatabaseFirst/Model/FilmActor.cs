using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sakila.Domain.Model;

public partial class FilmActor
{
    public int ActorId { get; set; }

    public int FilmId { get; set; }

    public DateTime LastUpdate { get; set; }

    public Actor Actor { get; set; } = null!;

    public Film Film { get; set; } = null!;
}
