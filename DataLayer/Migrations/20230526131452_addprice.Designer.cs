﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(DataDbContext))]
    [Migration("20230526131452_addprice")]
    partial class addprice
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClinicAnimalClinicVisit", b =>
                {
                    b.Property<int>("ClinicAnimalsId")
                        .HasColumnType("int");

                    b.Property<int>("ClinicVisitsId")
                        .HasColumnType("int");

                    b.HasKey("ClinicAnimalsId", "ClinicVisitsId");

                    b.HasIndex("ClinicVisitsId");

                    b.ToTable("ClinicAnimalClinicVisit");
                });

            modelBuilder.Entity("DataLayer.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CoatColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("HasMicrochip")
                        .HasColumnType("bit");

                    b.Property<string>("MicrochipNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Typology")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Animals");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("DataLayer.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("DataLayer.ClinicVisit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DescriptionBeforeVisit")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("ExamTypology")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TreatmentDescription")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("VisitDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ClinicVisits");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("DataLayer.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<string>("FiscalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasAnimal")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("DataLayer.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BusinessName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessStreet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessTelNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedicineName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumArmadietto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumCassetto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<int>("QtyInStock")
                        .HasColumnType("int");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.Property<int?>("Usage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DataLayer.ProductCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<string>("Prescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCarts");
                });

            modelBuilder.Entity("MunicipalAnimalMunicipalVisit", b =>
                {
                    b.Property<int>("MunicipalAnimalsId")
                        .HasColumnType("int");

                    b.Property<int>("MunicipalVisitsId")
                        .HasColumnType("int");

                    b.HasKey("MunicipalAnimalsId", "MunicipalVisitsId");

                    b.HasIndex("MunicipalVisitsId");

                    b.ToTable("MunicipalAnimalMunicipalVisit");
                });

            modelBuilder.Entity("DataLayer.ClinicAnimal", b =>
                {
                    b.HasBaseType("DataLayer.Animal");

                    b.Property<string>("OwnerLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerName")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("ClinicAnimal", (string)null);
                });

            modelBuilder.Entity("DataLayer.MunicipalAnimal", b =>
                {
                    b.HasBaseType("DataLayer.Animal");

                    b.Property<string>("FileExtension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsInHospital")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Picture")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("RecoveryEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RecoveryStart")
                        .HasColumnType("datetime2");

                    b.ToTable("MunicipalAnimal", (string)null);
                });

            modelBuilder.Entity("DataLayer.MunicipalVisit", b =>
                {
                    b.HasBaseType("DataLayer.ClinicVisit");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.ToTable("MunicipalVisit", (string)null);
                });

            modelBuilder.Entity("ClinicAnimalClinicVisit", b =>
                {
                    b.HasOne("DataLayer.ClinicAnimal", null)
                        .WithMany()
                        .HasForeignKey("ClinicAnimalsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.ClinicVisit", null)
                        .WithMany()
                        .HasForeignKey("ClinicVisitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Owner", b =>
                {
                    b.HasOne("DataLayer.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("DataLayer.ProductCart", b =>
                {
                    b.HasOne("DataLayer.Cart", "Cart")
                        .WithMany("ProductsInCart")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Product", "Product")
                        .WithMany("ProductsInCart")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MunicipalAnimalMunicipalVisit", b =>
                {
                    b.HasOne("DataLayer.MunicipalAnimal", null)
                        .WithMany()
                        .HasForeignKey("MunicipalAnimalsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.MunicipalVisit", null)
                        .WithMany()
                        .HasForeignKey("MunicipalVisitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.ClinicAnimal", b =>
                {
                    b.HasOne("DataLayer.Animal", null)
                        .WithOne()
                        .HasForeignKey("DataLayer.ClinicAnimal", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.MunicipalAnimal", b =>
                {
                    b.HasOne("DataLayer.Animal", null)
                        .WithOne()
                        .HasForeignKey("DataLayer.MunicipalAnimal", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.MunicipalVisit", b =>
                {
                    b.HasOne("DataLayer.ClinicVisit", null)
                        .WithOne()
                        .HasForeignKey("DataLayer.MunicipalVisit", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Cart", b =>
                {
                    b.Navigation("ProductsInCart");
                });

            modelBuilder.Entity("DataLayer.Product", b =>
                {
                    b.Navigation("ProductsInCart");
                });
#pragma warning restore 612, 618
        }
    }
}
