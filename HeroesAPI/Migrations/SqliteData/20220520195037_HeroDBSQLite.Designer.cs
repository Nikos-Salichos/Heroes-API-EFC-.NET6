﻿// <auto-generated />
using HeroesAPI.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HeroesAPI.Migrations.SqliteData
{
    [DbContext(typeof(SqliteContext))]
    [Migration("20220520195037_HeroDBSQLite")]
    partial class HeroDBSQLite
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("HeroesAPI.Models.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Heroes");

                    b.HasData(
                        new
                        {
                            Id = 9,
                            FirstName = "Thor",
                            LastName = "Odinson",
                            Name = "Thor",
                            Place = "Asgard"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
