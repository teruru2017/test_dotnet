using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using octa_dotnet.Entities;

namespace octa_dotnet.Data
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airdrop> Airdrops { get; set; } = null!;
        public virtual DbSet<Box> Boxes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("octa5458_msdb");

            modelBuilder.Entity<Airdrop>(entity =>
            {
                entity.ToTable("airdrop");

                entity.Property(e => e.AirdropId).ValueGeneratedNever();

                entity.Property(e => e.Account)
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.BoxId).HasColumnName("Box_Id");

                entity.Property(e => e.BoxType).HasColumnName("Box_Type");

                entity.Property(e => e.Date)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Img)
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Box>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Box");

                entity.Property(e => e.BoxId)
                    .HasMaxLength(10)
                    .HasColumnName("Box_ID")
                    .IsFixedLength();

                entity.Property(e => e.BoxName)
                    .HasMaxLength(10)
                    .HasColumnName("Box_Name")
                    .IsFixedLength();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
