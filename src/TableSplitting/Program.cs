using Microsoft.EntityFrameworkCore;
using TableSplitting.Inftrastructure;
using TableSplitting.Model;

Console.WriteLine("Hello, Table Splitting!");

string connectionString = "Data Source=(local);Initial Catalog=TableSplittingDb;Integrated Security=True;TrustServerCertificate=True";

// dotnet add package Microsoft.EntityFrameworkCore.SqlServer
DbContextOptions dbContextOptions = new DbContextOptionsBuilder()
    .UseSqlServer(connectionString)
    .Options;

var context = new AppDbContext(dbContextOptions);

context.Database.EnsureCreated();

await SeedDataAsync(context);

var query = context.Attachments.Select(a => new AttachmentInfo
{
    Id = a.Id,
    ContentType = a.ContentType,
    Description = a.Description,
    Title = a.Title,
});


var attachments = context.Attachments.ToList();

foreach (var attachment in attachments)
{
    Console.WriteLine(attachment.Title);
}

var selectedAttachment = await context.Attachments
    .FirstAsync();

Console.WriteLine(selectedAttachment.Content.Length);



static async Task SeedDataAsync(AppDbContext context)
{
    for (int i = 0; i < 1000; i++)
    {
        var attachment = new Attachment
        {
            Title = "Lorem",
            ContentType = "application/pdf",
            Description = "Lorem ipsum",
            Filename = "file1.pdf",
            Content = Enumerable.Repeat((byte)1, 1_000_000).ToArray()
        };

        await context.Attachments.AddAsync(attachment);
    }

    await context.SaveChangesAsync();
}

