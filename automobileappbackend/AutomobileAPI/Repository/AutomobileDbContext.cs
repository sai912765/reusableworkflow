using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AutomobileAPI.Repository.Models;

namespace AutomobileAPI.Repository
{
    public partial class AutomobileDbContext : DbContext
    {
        public AutomobileDbContext()
        {
        }

        public AutomobileDbContext(DbContextOptions<AutomobileDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarForSale> CarForSales { get; set; } = null!;
        public virtual DbSet<CarMake> CarMakes { get; set; } = null!;
        public virtual DbSet<CarModel> CarModels { get; set; } = null!;
        public virtual DbSet<VwCarsForSale> VwCarsForSales { get; set; } = null!;
        public virtual DbSet<CarModelsMulti> CarModelsMultis { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:AutomobileDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarForSale>(entity =>
            {
                entity.HasOne(d => d.CarModel)
                    .WithMany(p => p.CarForSales)
                    .HasForeignKey(d => d.CarModelId)
                    .HasConstraintName("FK__CarForSal__CarMo__66603565");
            });

            modelBuilder.Entity<CarModel>(entity =>
            {
                entity.HasOne(d => d.CarMake)
                    .WithMany(p => p.CarModels)
                    .HasForeignKey(d => d.CarMakeId)
                    .HasConstraintName("FK__CarModel__CarMak__6383C8BA");
            });

            modelBuilder.Entity<VwCarsForSale>(entity =>
            {
                entity.ToView("vwCarsForSale");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
