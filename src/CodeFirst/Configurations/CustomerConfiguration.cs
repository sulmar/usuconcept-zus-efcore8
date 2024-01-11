using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CodeFirst.Configurations;

internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder
           .Property(p => p.FirstName)
           .IsRequired()
           .HasMaxLength(20);

        builder
            .Property(p => p.LastName)
            .IsRequired()
            .HasMaxLength(20);

        builder
          .Property(p => p.Email)
          .HasMaxLength(250);
    }
}
