using TrackingChanges.Model;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, Tracking Changes!");

var context = new SakilaContext();

var customer = context.Customers.First();

customer.Active = customer.Active == "1" ? "0" : "1";

context.SaveChanges();


