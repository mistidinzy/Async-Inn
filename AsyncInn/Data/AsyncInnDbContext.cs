using System;
using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel {
                    ID = 54,
                    Name = "BananaTown",
                    StreetAddress = "42 Wallaby Way",
                    City = "Sydney",
                    State = "Iowa",
                    Country = "Australia",
                    Phone = "333-222-1111"
                }
            );
        }
    }
}

