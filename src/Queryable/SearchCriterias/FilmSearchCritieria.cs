using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queryable.SearchCriterias;

internal class FilmSearchCritieria
{
    public string Title { get; set; }
    public string? Rating { get; set; }
    public decimal? From { get; set; }
    public decimal? To { get; set; }

}
