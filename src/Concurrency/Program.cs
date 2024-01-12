using Infrastructure;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, Concurrency!");

using var context = new SakilaContext();

try
{
    var customer = context.Customers.Find(1);
    customer.Email = "a@domain.com";
    customer.LastName = "Test";

    Console.WriteLine($"{context.Entry(customer).Property(p => p.Email).OriginalValue}");


    // simulate a concurrency conflict
    context.Database.ExecuteSqlRaw(
        "UPDATE dbo.customer SET email = 'b@domain.com' WHERE customer_id = 1");

    // Attempt to save changes to the database
    context.SaveChanges();

}
catch(Exception e )
{

}

/*
 ALTER TABLE customer
	ADD [Version] ROWVERSION
*/