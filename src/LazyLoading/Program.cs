using Infrastructure;

Console.WriteLine("Hello, Lazy Loading!");

using var context = new SakilaContext();

// Leniwe ładowanie (Lazy Loading) z użyciem Proxy

//var customers = context.Customers.ToList();

//foreach(var customer in customers)
//{
//    Console.WriteLine($"{customer.FirstName} {customer.LastName}");

//    Console.WriteLine($"{customer.Address.City.City1} {customer.Address.City.Country.Country1}"); 
//}

//customers.Dump();

// Leniwe ładowanie (Lazy Loading) bez użycia Proxy

var customers = context.Customers.ToList();

foreach (var customer in customers)
{
    Console.WriteLine($"{customer.FirstName} {customer.LastName}");
    
    Console.WriteLine($"{customer.Address.Address1}");

    await Task.Delay(1000);
}


