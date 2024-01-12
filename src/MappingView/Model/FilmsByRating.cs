using System.ComponentModel.DataAnnotations.Schema;

namespace MappingView.Model;

public class FilmsByRating
{
    public string Rating { get; set; }

    public int FilmCount { get; set; }

    public override string ToString() => $"{Rating} {FilmCount}";
}
