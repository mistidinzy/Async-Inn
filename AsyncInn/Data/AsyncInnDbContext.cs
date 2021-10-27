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
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel {
                    Id = 54,
                    Name = "BananaTown",
                    StreetAddress = "42 Wallaby Way",
                    City = "Sydney",
                    State = "Iowa",
                    Country = "Australia",
                    Phone = "333-222-1111"
                }
            );

            modelBuilder.Entity<Amenity>().HasData(
                new Amenity
                {
                    Id = 1,
                    Name = "Mini Fridge"
                },

                new Amenity
                {
                    Id = 2,
                    Name = "Coffee Pot"
                },

                new Amenity
                {
                    Id = 3,
                    Name = "Free Wifi"
                }
            );
        }
    }
}

