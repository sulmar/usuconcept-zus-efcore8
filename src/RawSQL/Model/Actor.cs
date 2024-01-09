using System;
using System.Collections.Generic;

namespace RawSQL.Model;

public partial record Actor
{
    public int ActorId { get; init; }

    public string FirstName { get; init; } = null!;

    public string LastName { get; init; } = null!;

    public DateTime LastUpdate { get; init; }

    public virtual ICollection<FilmActor> FilmActors { get; init; } = new List<FilmActor>();
}
