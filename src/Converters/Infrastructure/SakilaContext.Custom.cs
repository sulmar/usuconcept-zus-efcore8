using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{

    public partial class SakilaContext : DbContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            

            //var converter = new BoolToTwoValuesConverter<char>('0', '1');

            var converter = new BoolToCharConverter('0', '1');

            modelBuilder.Entity<Customer>()
                .Property(p => p.Active)
                .HasColumnType("char(1)")
                .HasConversion(converter);
        }
    }
}
