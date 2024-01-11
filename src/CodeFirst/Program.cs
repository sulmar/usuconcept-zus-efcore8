using CodeFirst.Infrastructure;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, Code First!");

string connectionString = "Data Source=DESKTOP-RB5EAJ4\\SQLEXPRESS;Initial Catalog=ApplicationDb;Integrated Security=True;Encrypt=False;Application Name=CodeFirstApp";

var options = new DbContextOptionsBuilder<ApplicationDbContext>()
    .UseSqlServer(connectionString)
    .Options;

var context = new ApplicationDbContext(options);

// var dbCreated = context.Database.EnsureCreated(); // uwaga: nie można później używać migracji

//if (dbCreated)
//{
//    Console.WriteLine("Databased created.");
//}

// dotnet tool install --global dotnet-ef --version 8.0.0

// dotnet add package Microsoft.EntityFrameworkCore.Design 

context.Database.Migrate();


var products = context.Products.OrderBy(p => p.Weight).ToList();


Console.WriteLine(products);