﻿// <auto-generated />
using System;
using Async_Inn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AsyncInn.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    [Migration("20230203175256_EditRoomToRoomStyle")]
    partial class EditRoomToRoomStyle
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Async_Inn.Models.Amenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mini Fridge"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Coffee Pot"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Free Wifi"
                        });
                });

            modelBuilder.Entity("Async_Inn.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HotelRoomHotelId")
                        .HasColumnType("int");

                    b.Property<int?>("HotelRoomRoomId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HotelRoomHotelId", "HotelRoomRoomId");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 54,
                            City = "Sydney",
                            Country = "Australia",
                            Name = "Banana Town",
                            Phone = "333-222-1111",
                            State = "Iowa",
                            StreetAddress = "42 Wallaby Way"
                        },
                        new
                        {
                            Id = 4,
                            City = "Gumdropton",
                            Country = "Candy Land",
                            Name = "Cupcake Cabins",
                            Phone = "123-445-9922",
                            State = "Chocolateville",
                            StreetAddress = "45 Sugar Street"
                        },
                        new
                        {
                            Id = 7,
                            City = "Schedar",
                            Country = "The Milky Way",
                            Name = "Northern Sky Inn",
                            Phone = "270-323-4106",
                            State = "Cassiopeia",
                            StreetAddress = "7746 Starlight Lane"
                        });
                });

            modelBuilder.Entity("Async_Inn.Models.HotelRoom", b =>
                {
                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<bool>("IsHaunted")
                        .HasColumnType("bit");

                    b.Property<bool>("PetFriendly")
                        .HasColumnType("bit");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("HotelId", "RoomId");

                    b.ToTable("HotelRooms");

                    b.HasData(
                        new
                        {
                            HotelId = 54,
                            RoomId = 1,
                            IsHaunted = false,
                            PetFriendly = true,
                            RoomNumber = 101
                        },
                        new
                        {
                            HotelId = 4,
                            RoomId = 2,
                            IsHaunted = true,
                            PetFriendly = true,
                            RoomNumber = 101
                        },
                        new
                        {
                            HotelId = 7,
                            RoomId = 3,
                            IsHaunted = false,
                            PetFriendly = true,
                            RoomNumber = 201
                        });
                });

            modelBuilder.Entity("Async_Inn.Models.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("DATE");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("Async_Inn.Models.RoomAmenity", b =>
                {
                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("AmenityId")
                        .HasColumnType("int");

                    b.HasKey("RoomId", "AmenityId");

                    b.HasIndex("AmenityId");

                    b.ToTable("RoomAmenities");
                });

            modelBuilder.Entity("Async_Inn.Models.RoomStyle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("HotelRoomHotelId")
                        .HasColumnType("int");

                    b.Property<int?>("HotelRoomRoomId")
                        .HasColumnType("int");

                    b.Property<int>("Layout")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HotelRoomHotelId", "HotelRoomRoomId");

                    b.ToTable("RoomStyles");
                });

            modelBuilder.Entity("Async_Inn.Models.Hotel", b =>
                {
                    b.HasOne("Async_Inn.Models.HotelRoom", null)
                        .WithMany("Hotels")
                        .HasForeignKey("HotelRoomHotelId", "HotelRoomRoomId");
                });

            modelBuilder.Entity("Async_Inn.Models.RoomAmenity", b =>
                {
                    b.HasOne("Async_Inn.Models.Amenity", "Amenity")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("AmenityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Async_Inn.Models.RoomStyle", "Room")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Amenity");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Async_Inn.Models.RoomStyle", b =>
                {
                    b.HasOne("Async_Inn.Models.HotelRoom", null)
                        .WithMany("RoomStyles")
                        .HasForeignKey("HotelRoomHotelId", "HotelRoomRoomId");
                });

            modelBuilder.Entity("Async_Inn.Models.Amenity", b =>
                {
                    b.Navigation("RoomAmenities");
                });

            modelBuilder.Entity("Async_Inn.Models.HotelRoom", b =>
                {
                    b.Navigation("Hotels");

                    b.Navigation("RoomStyles");
                });

            modelBuilder.Entity("Async_Inn.Models.RoomStyle", b =>
                {
                    b.Navigation("RoomAmenities");
                });
#pragma warning restore 612, 618
        }
    }
}
