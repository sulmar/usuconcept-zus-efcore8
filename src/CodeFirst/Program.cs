using CodeFirst.Infrastructure;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, Code First!");

string connectionString = "Data Source=DESKTOP-RB5EAJ4\\SQLEXPRESS;Initial Catalog=ApplicationDb;Integrated Security=True;Encrypt=False;Application Name=CodeFirstApp";

var options = new DbContextOptionsBuilder<ApplicationDbContext>()
    .UseSqlServer(connectionString)
    .Options;

var context = new ApplicationDbContext(options);

var dbCreated = context.Database.EnsureCreated();

if (dbCreated)
{
    Console.WriteLine("Databased created.");
}


