﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RzrSite.DAL;

namespace RzrSite.DAL.Migrations
{
    [DbContext(typeof(RzrSiteDbContext))]
    [Migration("20200425125311_ProductLines")]
    partial class ProductLines
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("RzrSite.Models.Entities.Advantage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProductLineId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int>("Weight")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductLineId");

                    b.ToTable("Advantages");
                });

            modelBuilder.Entity("RzrSite.Models.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Weight")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("RzrSite.Models.Entities.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProductLineId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Weight")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductLineId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("RzrSite.Models.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("InStock")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProductLineId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int>("Weight")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductLineId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("RzrSite.Models.Entities.ProductLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .HasColumnType("TEXT");

                    b.Property<int>("Weight")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductLines");
                });

            modelBuilder.Entity("RzrSite.Models.Entities.Advantage", b =>
                {
                    b.HasOne("RzrSite.Models.Entities.ProductLine", null)
                        .WithMany("Advantages")
                        .HasForeignKey("ProductLineId");
                });

            modelBuilder.Entity("RzrSite.Models.Entities.Document", b =>
                {
                    b.HasOne("RzrSite.Models.Entities.ProductLine", null)
                        .WithMany("Documents")
                        .HasForeignKey("ProductLineId");
                });

            modelBuilder.Entity("RzrSite.Models.Entities.Product", b =>
                {
                    b.HasOne("RzrSite.Models.Entities.ProductLine", null)
                        .WithMany("Products")
                        .HasForeignKey("ProductLineId");
                });

            modelBuilder.Entity("RzrSite.Models.Entities.ProductLine", b =>
                {
                    b.HasOne("RzrSite.Models.Entities.Category", null)
                        .WithMany("ProductLines")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
