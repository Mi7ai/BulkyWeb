﻿// <auto-generated />
using BulkyWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BulkyWeb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230416163738_modelEntityAndDataSeed")]
    partial class modelEntityAndDataSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BulkyWeb.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 4,
                            DisplayOrder = 4,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 5,
                            DisplayOrder = 5,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 6,
                            DisplayOrder = 6,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 7,
                            DisplayOrder = 7,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 8,
                            DisplayOrder = 8,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 9,
                            DisplayOrder = 9,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 10,
                            DisplayOrder = 10,
                            Name = "Action"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
