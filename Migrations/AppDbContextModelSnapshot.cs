﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Weather.Data;

#nullable disable

namespace WeatherForecast.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyConsoleApp.Models.Forecast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("LocationID")
                        .HasColumnType("int");

                    b.Property<float>("MaxTemp")
                        .HasColumnType("real");

                    b.Property<float>("MinTemp")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("LocationID");

                    b.ToTable("Forecasts");
                });

            modelBuilder.Entity("MyConsoleApp.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Lat")
                        .HasColumnType("real");

                    b.Property<float>("Lon")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("MyConsoleApp.Models.Forecast", b =>
                {
                    b.HasOne("MyConsoleApp.Models.Location", "Location")
                        .WithMany("Forecasts")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("MyConsoleApp.Models.Location", b =>
                {
                    b.Navigation("Forecasts");
                });
#pragma warning restore 612, 618
        }
    }
}
