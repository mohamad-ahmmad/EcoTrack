﻿// <auto-generated />
using System;
using EcoTrack.PL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EcoTrack.PL.Migrations
{
    [DbContext(typeof(EcoTrackDBContext))]
    [Migration("20231120142855_seeding_users_locations")]
    partial class seedinguserslocations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EcoTrack.PL.Entities.Location", b =>
                {
                    b.Property<long>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            LocationId = -10L,
                            CityName = "Nablus",
                            CountryName = "Palestine"
                        },
                        new
                        {
                            LocationId = -9L,
                            CityName = "Jenin",
                            CountryName = "Palestine"
                        },
                        new
                        {
                            LocationId = -8L,
                            CityName = "Tokyo",
                            CountryName = "Japan"
                        },
                        new
                        {
                            LocationId = -7L,
                            CityName = "Seoul",
                            CountryName = "North Korea"
                        });
                });

            modelBuilder.Entity("EcoTrack.PL.Entities.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Deleteed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("LocationId")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.HasIndex("LocationId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = -10L,
                            BirthDate = new DateTime(2023, 11, 20, 16, 28, 55, 174, DateTimeKind.Local).AddTicks(9656),
                            Deleteed = false,
                            Email = "morsee@egy.pt",
                            FirstName = "Mer'e",
                            LastName = "Pharaoh",
                            LocationId = -10L,
                            Password = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
                            Username = "morse"
                        },
                        new
                        {
                            UserId = -9L,
                            BirthDate = new DateTime(2023, 11, 20, 16, 28, 55, 174, DateTimeKind.Local).AddTicks(9695),
                            Deleteed = false,
                            Email = "moghrabi@egy.pt",
                            FirstName = "Sal",
                            LastName = "Tan",
                            LocationId = -8L,
                            Password = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
                            Username = "mohammad"
                        });
                });

            modelBuilder.Entity("EcoTrack.PL.Entities.User", b =>
                {
                    b.HasOne("EcoTrack.PL.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });
#pragma warning restore 612, 618
        }
    }
}
