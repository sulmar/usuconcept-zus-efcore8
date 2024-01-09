using Infrastructure;


Console.WriteLine("Hello, Transactions!");

using var context = new SakilaContext();

// TODO: save in transaction

context.Customers.Add(new Customer { FirstName = "a", LastName = "a" });
context.SaveChanges();

context.Customers.Add(new Customer { FirstName = "b", LastName = "b" });
context.SaveChanges();

