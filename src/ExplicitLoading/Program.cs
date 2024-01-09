using Infrastructure;

Console.WriteLine("Hello, Explicit Loading!");

using var context = new SakilaContext();

var customers = context.Customers.ToList();

foreach(var customer in customers)
{
    // TODO: Load and display address
    Console.WriteLine(customer);

    // TODO: Load payments

    Console.WriteLine(customer.Payments.Sum(p=>p.Amount));


}
