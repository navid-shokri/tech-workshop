﻿// <auto-generated />
using System;
using EFDualContextTest.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFDualContextTest.Migrations
{
    [DbContext(typeof(OrderDbContext))]
    [Migration("20240825093437_seller_product")]
    partial class seller_product
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EFDualContextTest.Models.History", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("EFDualContextTest.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("char(36)");

                    b.Property<long>("TotalPrice")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EFDualContextTest.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("EFDualContextTest.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EFDualContextTest.Models.Seller", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("EFDualContextTest.Models.History", b =>
                {
                    b.HasOne("EFDualContextTest.Models.Person", null)
                        .WithMany("Histories")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFDualContextTest.Models.Order", b =>
                {
                    b.HasOne("EFDualContextTest.Models.Person", "Owner")
                        .WithMany("Orders")
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("EFDualContextTest.Models.Person", b =>
                {
                    b.OwnsOne("EFDualContextTest.Models.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("PersonId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("City")
                                .HasColumnType("longtext")
                                .HasColumnName("City");

                            b1.Property<string>("Street")
                                .HasColumnType("longtext")
                                .HasColumnName("Street");

                            b1.HasKey("PersonId");

                            b1.ToTable("Persons");

                            b1.WithOwner()
                                .HasForeignKey("PersonId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("EFDualContextTest.Models.Seller", b =>
                {
                    b.HasOne("EFDualContextTest.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EFDualContextTest.Models.Person", b =>
                {
                    b.Navigation("Histories");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
