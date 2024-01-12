using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

public partial class SakilaContext : DbContext
{
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Customer>()
        //    .Property(p => p.Email)
        //    .IsConcurrencyToken();

        //modelBuilder.Entity<Customer>()
        //   .Property(p => p.LastName)
        //   .IsConcurrencyToken();

        modelBuilder.Entity<Customer>()
           // .Property(p => p.Version)
            .Property<byte[]>("Version") // Ręczne utworzenie właściwości Shadow Property
            .IsRowVersion()
            .IsConcurrencyToken();
    }
}
