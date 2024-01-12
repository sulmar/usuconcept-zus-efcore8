// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using RawSQL;
using RawSQL.Model;

Console.WriteLine("Hello, SQL!");

var context = new SakilaContext();

// TODO: SQL "SELECT * FROM customer"

var sql = "SELECT * FROM customer";
var customers = context.Customers.FromSqlRaw(sql);

FormattableString sql2 = $"SELECT * FROM customer";
customers = context.Customers.FromSql(sql2);


/*
 modelBuilder.Entity<Actor>()
            .ToView("vw_GetActors");
*/


// TODO: SQL "SELECT COUNT(*) FROM Customer"


// EF Core 8.0
// TODO: SQL "SELECT first_name as FirstName, last_name as LastName FROM Customer"


// TODO: SQL "SELECT [first_name] AS FirstName, [last_name] AS LastName FROM [sakila].[dbo].[actor]" map to ActorDTO only firstname contains "a"


// TODO: SQL "EXEC usp_GetActors"


// TODO: Map SQL Functions





