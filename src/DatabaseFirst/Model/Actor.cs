using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sakila.Domain.Model;

public partial class Actor
{
    public int ActorId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime LastUpdate { get; set; }

    public ObservableCollection<FilmActor> FilmActors { get; set; } = new ObservableCollection<FilmActor>();
}
