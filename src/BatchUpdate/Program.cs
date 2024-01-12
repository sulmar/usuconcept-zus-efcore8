using TrackingChanges.Model;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, Batch Update!");

var context = new SakilaContext();

//var films = context.Films.ToList();

//foreach (var film in films)
//{
//    film.ReplacementCost += 1;
//}

//context.Films.ExecuteUpdate(s => s.SetProperty
//    (
//    property => property.ReplacementCost,
//    film => film.ReplacementCost + 1
//    )
//);

BatchUpdate(context);

BatchRemove(context);

static void BatchUpdate(SakilaContext context)
{
    context.Films.Where(film => film.RentalDuration > 5)
        .ExecuteUpdate(
            s => s.SetProperty
            (
            property => property.ReplacementCost,
            film => film.ReplacementCost + 1
            )
            .SetProperty
            (
                p => p.LastUpdate,
                film => DateTime.Now
            )

    );
}

static void BatchRemove(SakilaContext context)
{
    context.Actors
        .Where(a => a.FirstName.Contains("JOHN"))
        .ExecuteDelete();
}