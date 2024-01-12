using Microsoft.EntityFrameworkCore;
using Infrastructure;
using Queryable.SearchCriterias;
using System.Linq;

Console.WriteLine("Hello, Queryable!");

using var context = new SakilaContext();

// Search Criteria
string title = "ACADEMY";
string? rating = "PG";
decimal? from = null;
decimal? to = null;
int? original_language_id = 19;
DateTime toDate = DateTime.Parse("2024-01-12");

FilmSearchCritieria searchCritieria = new()
{
    Title = title,
    Rating = rating,
    From = from,
    To = to,
};

var query2 = context.Customers.Where(c => c.FirstName.StartsWith("A"));

// Wyświetlenie zapytania SQL
string sql = query2.ToQueryString();
Console.WriteLine(sql);

var query3 = context.Customers.AsEnumerable()
    .Where(c => c.FirstName[0] == 'A')    
    .ToList();

List<Film> films = GetFilmsBySearchCritieria(context, searchCritieria);

films.Dump();

Console.ReadLine();

static List<Film> GetFilmsBySearchCritieria(SakilaContext context, FilmSearchCritieria searchCritieria)
{
    IQueryable<Film> query = context.Films.AsQueryable()
        .Where(f => f.Title.Contains(searchCritieria.Title));

    if (!string.IsNullOrEmpty(searchCritieria.Rating))
    {
        query = query.Where(f => f.Rating == searchCritieria.Rating);
    }

    if (searchCritieria.From.HasValue)
    {
        query = query.Where(f => f.ReplacementCost >= searchCritieria.From.Value);
    }

    if (searchCritieria.To.HasValue)
    {
        query = query.Where(f => f.ReplacementCost <= searchCritieria.To.Value);
    }

    //if (original_language_id.HasValue)
    //    query = query.Where(f => f.OriginalLanguage.LanguageId < 19);

    query = query
        .OrderBy(f => f.ReleaseYear);

    query = query.TagWith("MyQuery");

    var sql = query.ToQueryString();

    Console.WriteLine( sql);

    var films = query.ToList();
    return films;
}