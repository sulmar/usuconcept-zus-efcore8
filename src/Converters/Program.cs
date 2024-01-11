using Infrastructure;

Console.WriteLine("Hello, Value Converters!");

using var context = new SakilaContext();

var customers = context.Customers.ToList();

customers.Dump();