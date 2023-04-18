﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiDiplom.Data;

#nullable disable

namespace WebApiDiplom.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApiDiplom.Models.BodyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BodyTypes");
                });

            modelBuilder.Entity("WebApiDiplom.Models.BrandCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BrandCars");
                });

            modelBuilder.Entity("WebApiDiplom.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarModelId")
                        .HasColumnType("int");

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<int>("Mileage")
                        .HasColumnType("int");

                    b.Property<bool>("Rented")
                        .HasColumnType("bit");

                    b.Property<DateTime>("YearOfIssue")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CarModelId");

                    b.HasIndex("ColorId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("WebApiDiplom.Models.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BodyTypeId")
                        .HasColumnType("int");

                    b.Property<int>("BrandCarId")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BodyTypeId");

                    b.HasIndex("BrandCarId");

                    b.ToTable("CarModels");
                });

            modelBuilder.Entity("WebApiDiplom.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DrivingExperience")
                        .HasColumnType("int");

                    b.Property<int>("Fines")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Passport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("WebApiDiplom.Models.ClientBrandCar", b =>
                {
                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("BrandCarId")
                        .HasColumnType("int");

                    b.HasKey("ClientId", "BrandCarId");

                    b.HasIndex("BrandCarId");

                    b.ToTable("ClientBrandCars");
                });

            modelBuilder.Entity("WebApiDiplom.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ColorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("WebApiDiplom.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("JobTitleId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Passport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JobTitleId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WebApiDiplom.Models.Fine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RentalContractId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RentalContractId");

                    b.ToTable("Fines");
                });

            modelBuilder.Entity("WebApiDiplom.Models.JobTitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobTitles");
                });

            modelBuilder.Entity("WebApiDiplom.Models.RentalContract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("RentalDuration")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("ClientId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("RentalContracts");
                });

            modelBuilder.Entity("WebApiDiplom.Models.Car", b =>
                {
                    b.HasOne("WebApiDiplom.Models.CarModel", "CarModel")
                        .WithMany("Cars")
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiDiplom.Models.Color", "Color")
                        .WithMany("Cars")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarModel");

                    b.Navigation("Color");
                });

            modelBuilder.Entity("WebApiDiplom.Models.CarModel", b =>
                {
                    b.HasOne("WebApiDiplom.Models.BodyType", "BodyType")
                        .WithMany("CarModels")
                        .HasForeignKey("BodyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiDiplom.Models.BrandCar", "BrandCar")
                        .WithMany("CarModels")
                        .HasForeignKey("BrandCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BodyType");

                    b.Navigation("BrandCar");
                });

            modelBuilder.Entity("WebApiDiplom.Models.ClientBrandCar", b =>
                {
                    b.HasOne("WebApiDiplom.Models.BrandCar", "BrandCar")
                        .WithMany("ClientBrandCars")
                        .HasForeignKey("BrandCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiDiplom.Models.Client", "Client")
                        .WithMany("ClientBrandCars")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BrandCar");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("WebApiDiplom.Models.Employee", b =>
                {
                    b.HasOne("WebApiDiplom.Models.JobTitle", "JobTitle")
                        .WithMany("Employees")
                        .HasForeignKey("JobTitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobTitle");
                });

            modelBuilder.Entity("WebApiDiplom.Models.Fine", b =>
                {
                    b.HasOne("WebApiDiplom.Models.RentalContract", "RentalContract")
                        .WithMany("Fines")
                        .HasForeignKey("RentalContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RentalContract");
                });

            modelBuilder.Entity("WebApiDiplom.Models.RentalContract", b =>
                {
                    b.HasOne("WebApiDiplom.Models.Car", "Car")
                        .WithMany("RentalContracts")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiDiplom.Models.Client", "Client")
                        .WithMany("RentalContracts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiDiplom.Models.Employee", "Employee")
                        .WithMany("RentalContracts")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Client");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("WebApiDiplom.Models.BodyType", b =>
                {
                    b.Navigation("CarModels");
                });

            modelBuilder.Entity("WebApiDiplom.Models.BrandCar", b =>
                {
                    b.Navigation("CarModels");

                    b.Navigation("ClientBrandCars");
                });

            modelBuilder.Entity("WebApiDiplom.Models.Car", b =>
                {
                    b.Navigation("RentalContracts");
                });

            modelBuilder.Entity("WebApiDiplom.Models.CarModel", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("WebApiDiplom.Models.Client", b =>
                {
                    b.Navigation("ClientBrandCars");

                    b.Navigation("RentalContracts");
                });

            modelBuilder.Entity("WebApiDiplom.Models.Color", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("WebApiDiplom.Models.Employee", b =>
                {
                    b.Navigation("RentalContracts");
                });

            modelBuilder.Entity("WebApiDiplom.Models.JobTitle", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("WebApiDiplom.Models.RentalContract", b =>
                {
                    b.Navigation("Fines");
                });
#pragma warning restore 612, 618
        }
    }
}
