﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NZWalks.API.Data;

#nullable disable

namespace NZWalks.API.Migrations
{
    [DbContext(typeof(NZWalksDbContext))]
    [Migration("20250629095825_Adding Images Table")]
    partial class AddingImagesTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NZWalks.API.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("949a1506-5b6a-4242-8bf9-0ad053ece225"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("deb1e3f2-e4e4-4d8e-ad2b-04a5e6859da7"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("f7d3ad4c-47f2-4773-8ac2-731a6da82bdb"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FileDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSizeBytes")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("images");
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e5ae10b1-653f-4d97-bde8-70c71258b480"),
                            Code = "AKL",
                            Name = "Auckland",
                            RegionImageUrl = "https://www.pexels.com/photo/auckland-city-with-a-view-of-the-sky-tower-new-zealand-17824133/"
                        },
                        new
                        {
                            Id = new Guid("add7dacc-8e4f-499c-859a-81f550e66ff0"),
                            Code = "NTL",
                            Name = "Northland",
                            RegionImageUrl = "https://www.pexels.com/photo/cape-reinga-lighthouse-at-sunset-north-island-new-zealand-17824120/"
                        },
                        new
                        {
                            Id = new Guid("bc0172df-33e1-4b24-b10c-5795bba96147"),
                            Code = "BOP",
                            Name = "Bay Of Plenty",
                            RegionImageUrl = "https://www.pexels.com/photo/crescent-shaped-coastline-of-mount-maunganui-in-new-zealand-21047861/"
                        },
                        new
                        {
                            Id = new Guid("00220bee-b7d6-4dc1-80f2-c968325cc30d"),
                            Code = "WGN",
                            Name = "Wellington",
                            RegionImageUrl = "https://www.pexels.com/photo/brown-hanging-bridge-surrounded-by-trees-403781/"
                        },
                        new
                        {
                            Id = new Guid("7dd441bc-6edd-40f8-a21c-15a908621e99"),
                            Code = "NSN",
                            Name = "Nelson",
                            RegionImageUrl = "https://www.pexels.com/photo/view-of-a-countryside-3396854/"
                        },
                        new
                        {
                            Id = new Guid("80393ee4-c338-4b54-a3c9-64c6f2e104f8"),
                            Code = "STL",
                            Name = "Southland",
                            RegionImageUrl = "https://www.pexels.com/photo/calm-lake-1353248/"
                        });
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Walk", b =>
                {
                    b.HasOne("NZWalks.API.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NZWalks.API.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
