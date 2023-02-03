using System;
using Async_Inn.Models;
using Async_Inn.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel {
                    Id = 54,
                    Name = "Banana Town",
                    StreetAddress = "42 Wallaby Way",
                    City = "Sydney",
                    State = "Iowa",
                    Country = "Australia",
                    Phone = "333-222-1111"
                },
                new Hotel {
                    Id = 4,
                    Name = "Cupcake Cabins",
                    StreetAddress = "45 Sugar Street",
                    City = "Gumdropton",
                    State = "Chocolateville",
                    Country = "Candy Land",
                    Phone = "123-445-9922"
                },
                new Hotel {
                    Id = 7,
                    Name = "Northern Sky Inn",
                    StreetAddress = "7746 Starlight Lane",
                    City = "Schedar",
                    State = "Cassiopeia",
                    Country = "The Milky Way",
                    Phone = "270-323-4106"
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

            modelBuilder.Entity<HotelRoom>() 
                .HasKey(hr => new { hr.HotelId, hr.RoomId }
            );

            modelBuilder.Entity<RoomAmenity>()
                .HasKey(ra => new { ra.RoomId, ra.AmenityId });
        }
    }
}

