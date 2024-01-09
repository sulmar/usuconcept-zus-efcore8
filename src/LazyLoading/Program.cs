using Infrastructure;

Console.WriteLine("Hello, Lazy Loading!");

using var context = new SakilaContext();

// TODO: Lazy Loading with Proxy

var customers = context.Customers.ToList();


customers.Dump();

// TODO: Lazy Loading (opoznione ladowanie) without Proxy



