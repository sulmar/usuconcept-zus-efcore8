using DatabaseFirst.CustomModel;
using Microsoft.EntityFrameworkCore;
using Sakila.Infrastructure;

Console.WriteLine("Hello, Database First!");


// dotnet ef dbcontext scaffold "Data Source=.\SQLEXPRESS;Initial Catalog=sakila;Integrated Security=True;Encrypt=False" Microsoft.EntityFrameworkCore.SqlServer -o .\Model --context-dir .\Infrastructure -n Sakila.Domain.Model --context-namespace Sakila.Infrastructure

using var context = new SakilaContext();

// var customers = context.Customers.Include(p=>p.Address).ToList();

var customers = context.Customers.ToList();

foreach (var customer in customers)
{
    Console.WriteLine($"{customer.FirstName} {customer.LastName} {customer.Address.Address1} {customer.Address.City.City1}");
}

var actors  = context.Actors.ToList();

// var awards = context.Awards.ToList();

// var customersCount = context.Database.SqlQuery<int>($"SELECT COUNT(*) AS Qty FROM customer").Single();
// Console.WriteLine(customersCount);

// EF Core 8.0
var customerInfos = context.Database.SqlQuery<CustomerInfo>($"EXEC uspGetCustomersInfo")
    .ToList();


Console.ReadLine();



