using BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Data
{
    public class AssignmentDbContext : DbContext
    {
        public AssignmentDbContext(DbContextOptions<AssignmentDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Insert Sample Data
            modelBuilder.Entity<CategoryEntity>().HasData(
                new CategoryEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Food"
                },
                new CategoryEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cosmetics"
                });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ProductEntity> Product { get; set; }
        public DbSet<CategoryEntity> Category { get; set; }
    }
}
