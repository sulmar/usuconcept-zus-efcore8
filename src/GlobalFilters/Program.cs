using Infrastructure;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, Global Filters!");

using var context = new SakilaContext();

// TODO: Move to global filters
var activeCustomers = context.Customers    
    .ToList();

activeCustomers.Dump();


var allCustomers = context.Customers.IgnoreQueryFilters().ToList();

allCustomers.Dump();