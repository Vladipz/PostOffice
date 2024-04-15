using System;
using lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace lab3.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Package> Packages { get; init; }
        // public DbSet<Person> Persons { get; init; }

        public AppDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Package>().HasKey(p => p.Id);
            // modelBuilder.Entity<Person>().HasKey(p => p.Id);


            // modelBuilder.Entity<Package>()
            // .HasOne(p => p.Receiver)
            // .WithMany()
            // .HasForeignKey(p => p.ReceiverId);
        }

    }
}
