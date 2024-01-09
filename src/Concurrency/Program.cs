using Infrastructure;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, Concurrency!");

using var context = new SakilaContext();

var customer = context.Customers.Find(1);
customer.Email = "a@domain.com";

// simulate a concurrency conflict
context.Database.ExecuteSqlRaw(
    "UPDATE dbo.customer SET email = 'b@domain.com' WHERE customer_id = 1");

context.Customers.Add(new Customer { FirstName = "b", LastName = "b" });

// Attempt to save changes to the database
context.SaveChanges();

