using Infrastructure;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, Global Filters!");

using var context = new SakilaContext();

var activeCustomers = context.Customers    
    .ToList();

activeCustomers.Dump();


var allCustomers = context.Customers.IgnoreQueryFilters().ToList();

allCustomers.Dump();