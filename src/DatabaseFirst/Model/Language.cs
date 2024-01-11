using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sakila.Domain.Model;

public partial class Language
{
    public byte LanguageId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime LastUpdate { get; set; }

    public ObservableCollection<Film> FilmLanguages { get; set; } = new ObservableCollection<Film>();

    public ObservableCollection<Film> FilmOriginalLanguages { get; set; } = new ObservableCollection<Film>();
}
