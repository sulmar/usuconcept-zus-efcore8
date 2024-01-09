
1. Zainstaluj narzedzia EF dla dotnet CLI
''' bash
dotnet tool install --global dotnet-ef
'''

2. Dodaj paczkę

dotnet add package Microsoft.EntityFrameworkCore.SqlServer

3. Dodaj paczkę

dotnet add package Microsoft.EntityFrameworkCore.Design

4. Dodaj paczkę

dotnet add package Microsoft.EntityFrameworkCore.Tools


5. Uruchom z linii polecen
''' bash
dotnet ef dbcontext scaffold "Data Source=(local);Initial Catalog=sakila;Integrated Security=True;TrustServerCertificate=True"  Microsoft.EntityFrameworkCore.SqlServer

'''


''' bash
dotnet ef dbcontext scaffold "Data Source=.\MSSQLSERVER;Initial Catalog=sakila;Integrated Security=True;TrustServerCertificate=True"  Microsoft.EntityFrame
workCore.SqlServer
'''


dotnet ef dbcontext scaffold "Data Source=(local);Initial Catalog=sakila;Integrated Security=True;TrustServerCertificate=True"  Microsoft.EntityFrameworkCore.SqlServer -f -o Infrastructure -n Sages.ABB.Infrastructure



 dotnet ef dbcontext scaffold "Name=ConnectionStrings:Sakila" Microsoft.EntityFrameworkCore.SqlServer -o ..\Sakila.Domain\Model  --context-dir ..\Sakila.Infrastructure\ -f -n Sakila.Domain.Model --context-namespace Sakila.Intrastructure