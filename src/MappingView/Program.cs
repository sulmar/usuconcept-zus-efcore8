using Microsoft.EntityFrameworkCore;
using Infrastructure;


Console.WriteLine("Hello, Mapping View!");


using var context = new SakilaContext();

var filmsByRatings = context.FilmsByRatings.ToList();


filmsByRatings.Dump();


