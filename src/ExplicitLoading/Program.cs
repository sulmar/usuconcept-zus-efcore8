using Infrastructure;

Console.WriteLine("Hello, Explicit Loading!");

using var context = new SakilaContext();

var customers = context.Customers.ToList();

foreach (var customer in customers)
{
    context.Entry(customer).Reference(p => p.Address).Load();
    context.Entry(customer.Address).Reference(p => p.City).Load();

    Console.WriteLine(customer);

    context.Entry(customer).Collection(p => p.Payments).Load();

    // customer.Payments = context.Payments.Where(c => c.CustomerId == c.CustomerId).ToList();

    Console.WriteLine(customer.Payments.Sum(p => p.Amount));


}
