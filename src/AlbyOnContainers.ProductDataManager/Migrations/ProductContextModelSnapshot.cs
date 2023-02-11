﻿// <auto-generated />
using System;
using AlbyOnContainers.ProductDataManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AlbyOnContainers.ProductDataManager.Migrations
{
    [DbContext(typeof(ProductContext))]
    partial class ProductContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AlbyOnContainers.ProductDataManager.Models.Attr", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AttrTypeId")
                        .IsConcurrencyToken()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .IsConcurrencyToken()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModified")
                        .IsConcurrencyToken()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ProductId")
                        .IsConcurrencyToken()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AttrTypeId");

                    b.HasIndex("ProductId");

                    b.ToTable("Attrs");
                });

            modelBuilder.Entity("AlbyOnContainers.ProductDataManager.Models.AttrType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .IsConcurrencyToken()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModified")
                        .IsConcurrencyToken()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AttrTypes");
                });

            modelBuilder.Entity("AlbyOnContainers.ProductDataManager.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .IsConcurrencyToken()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModified")
                        .IsConcurrencyToken()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ParentId")
                        .IsConcurrencyToken()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AlbyOnContainers.ProductDataManager.Models.CategoryLevel", b =>
                {
                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid");

                    b.Property<string>("ParentName")
                        .HasColumnType("text");

                    b.ToTable((string)null);

                    b.ToView("categories_view", (string)null);
                });

            modelBuilder.Entity("AlbyOnContainers.ProductDataManager.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .IsConcurrencyToken()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .IsConcurrencyToken()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModified")
                        .IsConcurrencyToken()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("AlbyOnContainers.ProductDataManager.Models.Attr", b =>
                {
                    b.HasOne("AlbyOnContainers.ProductDataManager.Models.AttrType", "AttrType")
                        .WithMany("Attrs")
                        .HasForeignKey("AttrTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlbyOnContainers.ProductDataManager.Models.Product", "Product")
                        .WithMany("Attrs")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttrType");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AlbyOnContainers.ProductDataManager.Models.Category", b =>
                {
                    b.HasOne("AlbyOnContainers.ProductDataManager.Models.Category", "Parent")
                        .WithMany("Categories")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("AlbyOnContainers.ProductDataManager.Models.Product", b =>
                {
                    b.HasOne("AlbyOnContainers.ProductDataManager.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("AlbyOnContainers.ProductDataManager.Models.AttrType", b =>
                {
                    b.Navigation("Attrs");
                });

            modelBuilder.Entity("AlbyOnContainers.ProductDataManager.Models.Category", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("AlbyOnContainers.ProductDataManager.Models.Product", b =>
                {
                    b.Navigation("Attrs");
                });
#pragma warning restore 612, 618
        }
    }
}
