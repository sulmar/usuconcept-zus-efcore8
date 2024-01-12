using Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;


Console.WriteLine("Hello, Transactions!");

using var context = new SakilaContext();

// SavepointsTransaction(context);

Console.ReadLine();

// TODO: save in transaction
// NativeTransaction(context);

static void SavepointsTransaction(SakilaContext context)
{
    using IDbContextTransaction transaction = context.Database.BeginTransaction();

    try
    {
        context.Actors.Add(new Actor { FirstName = "a", LastName = "a" });
        context.SaveChanges();

        transaction.CreateSavepoint("BeforeMoreActors");

        context.Actors.Add(new Actor { FirstName = "b", LastName = "b" });
        context.Actors.Add(new Actor { FirstName = "c", LastName = "c" });

        context.SaveChanges();


        throw new ApplicationException();

        transaction.Commit();




    }
    catch (Exception)
    {
        transaction.RollbackToSavepoint("BeforeMoreActors");
    }

}

static void NativeTransaction(SakilaContext context)
{
    IDbContextTransaction transaction = context.Database.BeginTransaction();

    try
    {
        context.Actors.Add(new Actor { FirstName = "a", LastName = "a" });
        context.SaveChanges();

        context.Actors.Add(new Actor { FirstName = "b", LastName = "b" });
        context.SaveChanges();

        throw new ApplicationException();

        // transaction.Commit();

    }
    catch (Exception)
    {
        // transaction.Rollback();
    }
    
}

