using Infrastructure;

Console.WriteLine("Hello, Conventions!");

using var context = new SakilaContext();

var customers = context.Customers.ToList();

customers.Dump();