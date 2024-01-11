Console.WriteLine("Hello, Database First!");


// dotnet ef dbcontext scaffold "Data Source=.\SQLEXPRESS;Initial Catalog=sakila;Integrated Security=True;Encrypt=False" Microsoft.EntityFrameworkCore.SqlServer -o .\Model --context-dir .\Infrastructure -n Sakila.Domain.Model --context-namespace Sakila.Infrastructure