﻿// <auto-generated />
using System;
using BandIt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BandIt.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932");

            modelBuilder.Entity("BandIt.Models.Band", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BandManagerId");

                    b.Property<string>("BandName");

                    b.Property<DateTime?>("DateFounded");

                    b.Property<string>("Genre");

                    b.Property<string>("Logo");

                    b.Property<string>("Members");

                    b.Property<string>("Origin");

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.HasIndex("BandManagerId");

                    b.ToTable("Band");
                });

            modelBuilder.Entity("BandIt.Models.Concert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcertName");

                    b.Property<DateTime?>("Date");

                    b.Property<int?>("PerformingBandId");

                    b.Property<decimal>("TicketPrice");

                    b.Property<string>("Venue");

                    b.HasKey("Id");

                    b.HasIndex("PerformingBandId");

                    b.ToTable("Concert");
                });

            modelBuilder.Entity("BandIt.Models.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<int>("Experience");

                    b.Property<string>("ManagerName");

                    b.Property<string>("Nationality");

                    b.HasKey("Id");

                    b.ToTable("Manager");
                });

            modelBuilder.Entity("BandIt.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ArtistId");

                    b.Property<int>("Length");

                    b.Property<string>("Name");

                    b.Property<decimal>("Rating");

                    b.Property<DateTime?>("ReleaseDate");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Song");
                });

            modelBuilder.Entity("BandIt.Models.Band", b =>
                {
                    b.HasOne("BandIt.Models.Manager", "BandManager")
                        .WithMany("Bands")
                        .HasForeignKey("BandManagerId");
                });

            modelBuilder.Entity("BandIt.Models.Concert", b =>
                {
                    b.HasOne("BandIt.Models.Band", "PerformingBand")
                        .WithMany("Concerts")
                        .HasForeignKey("PerformingBandId");
                });

            modelBuilder.Entity("BandIt.Models.Song", b =>
                {
                    b.HasOne("BandIt.Models.Band", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistId");
                });
#pragma warning restore 612, 618
        }
    }
}