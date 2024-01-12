using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableSplitting.Model;

namespace TableSplitting.Inftrastructure;

internal class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Attachment> Attachments { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<DetailedAttachment>(
            detailAttachment =>
            {
                detailAttachment.ToTable("Attachments");
                detailAttachment.Property(p => p.ContentType).HasColumnName(nameof(Attachment.ContentType));
            }
        );

        modelBuilder.Entity<Attachment>(
            attachment =>
            {
                attachment.ToTable("Attachments");
                attachment.Property(p => p.ContentType).HasColumnName(nameof(Attachment.ContentType));

                attachment.HasOne(options => options.DetailedAttachment).WithOne()
                    .HasForeignKey<DetailedAttachment>(fk => fk.Id);
            });

    }
}
