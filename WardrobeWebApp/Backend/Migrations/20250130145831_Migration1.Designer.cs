﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(WardrobeDBContext))]
    [Migration("20250130145831_Migration1")]
    partial class Migration1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Backend.Models.ClothingItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Occasion")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Clothings");
                });

            modelBuilder.Entity("Backend.Models.Colour", b =>
                {
                    b.Property<int>("ColourId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ColourId"));

                    b.Property<byte>("A")
                        .HasColumnType("tinyint");

                    b.Property<byte>("B")
                        .HasColumnType("tinyint");

                    b.Property<int?>("ClothingItemId")
                        .HasColumnType("int");

                    b.Property<byte>("G")
                        .HasColumnType("tinyint");

                    b.Property<byte>("R")
                        .HasColumnType("tinyint");

                    b.Property<int?>("UserProfileUserId")
                        .HasColumnType("int");

                    b.HasKey("ColourId");

                    b.HasIndex("ClothingItemId");

                    b.HasIndex("UserProfileUserId");

                    b.ToTable("Colour");
                });

            modelBuilder.Entity("Backend.Models.Outfit", b =>
                {
                    b.Property<int>("OutfitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OutfitId"));

                    b.Property<string>("ClothingItemsIds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OutfitId");

                    b.ToTable("Outfits");
                });

            modelBuilder.Entity("Backend.Models.UserLogin", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Backend.Models.UserProfile", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Backend.Models.WearingHistory", b =>
                {
                    b.Property<int>("OutfitID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OutfitID"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("OutfitID");

                    b.ToTable("WearingHistories");
                });

            modelBuilder.Entity("Backend.Models.Colour", b =>
                {
                    b.HasOne("Backend.Models.ClothingItem", null)
                        .WithMany("Colours")
                        .HasForeignKey("ClothingItemId");

                    b.HasOne("Backend.Models.UserProfile", null)
                        .WithMany("FavouriteColours")
                        .HasForeignKey("UserProfileUserId");
                });

            modelBuilder.Entity("Backend.Models.ClothingItem", b =>
                {
                    b.Navigation("Colours");
                });

            modelBuilder.Entity("Backend.Models.UserProfile", b =>
                {
                    b.Navigation("FavouriteColours");
                });
#pragma warning restore 612, 618
        }
    }
}
