using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Property.EntityFramework.Context
{
    using Property.EntityFramework.Models;
    public partial class RoofstockDbContext : DbContext
    {
        public RoofstockDbContext()
        {
        }

        public RoofstockDbContext(DbContextOptions<RoofstockDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Property> Properties { get; set; }

        public virtual DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Property>(entity =>
            {
                entity.Property(e => e.Id);

                entity.Property(e => e.ListPrice).HasColumnType("decimal(20, 2)").IsRequired();

                entity.Property(e => e.MonthlyRent).HasColumnType("decimal(20, 2)").IsRequired();

                entity.Property(e => e.YearBuilt)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                // One way mapping.
                entity.HasOne(e => e.Address).WithOne();

            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn();

                entity.Property(e => e.Address1).HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Address2).HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.City).HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Country).HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.County).HasMaxLength(100)
                    .IsUnicode(false);
                
                entity.Property(e => e.District).HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State).HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Zip).HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ZipPlus4).HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
