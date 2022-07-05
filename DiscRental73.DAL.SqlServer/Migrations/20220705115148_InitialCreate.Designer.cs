﻿// <auto-generated />
using System;
using DatabaseStorage.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DiscRental73.DAL.SqlServer.Migrations
{
    [DbContext(typeof(DiscRentalDb))]
    [Migration("20220705115148_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DatabaseStorage.Entities.Base.Disc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfRelease")
                        .HasColumnType("datetime2");

                    b.Property<int>("DiscType")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Discs");
                });

            modelBuilder.Entity("DatabaseStorage.Entities.Base.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("ContactNumber")
                        .IsUnique();

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("DatabaseStorage.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("DiscId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiscId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DatabaseStorage.Entities.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfIssue")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfRental")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("PledgeSum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal?>("ReturnSum")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProductId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("DatabaseStorage.Entities.Sell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfSell")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProductId");

                    b.ToTable("Sells");
                });

            modelBuilder.Entity("DatabaseStorage.Entities.BluRayDisc", b =>
                {
                    b.HasBaseType("DatabaseStorage.Entities.Base.Disc");

                    b.Property<string>("Info")
                        .HasMaxLength(1023)
                        .HasColumnType("nvarchar(1023)");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SystemRequirements")
                        .HasMaxLength(1023)
                        .HasColumnType("nvarchar(1023)");

                    b.ToTable("BluRayDiscs");
                });

            modelBuilder.Entity("DatabaseStorage.Entities.CdDisc", b =>
                {
                    b.HasBaseType("DatabaseStorage.Entities.Base.Disc");

                    b.Property<string>("Genre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("NumberOfTracks")
                        .HasColumnType("int");

                    b.Property<string>("Performer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.ToTable("CdDiscs");
                });

            modelBuilder.Entity("DatabaseStorage.Entities.DvdDisc", b =>
                {
                    b.HasBaseType("DatabaseStorage.Entities.Base.Disc");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Info")
                        .HasMaxLength(1023)
                        .HasColumnType("nvarchar(1023)");

                    b.Property<string>("Plot")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.ToTable("DvdDiscs");
                });

            modelBuilder.Entity("DatabaseStorage.Entities.Client", b =>
                {
                    b.HasBaseType("DatabaseStorage.Entities.Base.Person");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("DatabaseStorage.Entities.Employee", b =>
                {
                    b.HasBaseType("DatabaseStorage.Entities.Base.Person");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<decimal?>("Prize")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DatabaseStorage.Entities.Product", b =>
                {
                    b.HasOne("DatabaseStorage.Entities.Base.Disc", "Disc")
                        .WithMany()
                        .HasForeignKey("DiscId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disc");
                });

            modelBuilder.Entity("DatabaseStorage.Entities.Rental", b =>
                {
                    b.HasOne("DatabaseStorage.Entities.Client", "Client")
                        .WithMany("Rentals")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseStorage.Entities.Employee", "Employee")
                        .WithMany("Rentals")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseStorage.Entities.Product", "Product")
                        .WithMany("Rentals")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Employee");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DatabaseStorage.Entities.Sell", b =>
                {
                    b.HasOne("DatabaseStorage.Entities.Employee", "Employee")
                        .WithMany("Sells")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseStorage.Entities.Product", "Product")
                        .WithMany("Sells")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DatabaseStorage.Entities.BluRayDisc", b =>
                {
                    b.HasOne("DatabaseStorage.Entities.Base.Disc", null)
                        .WithOne()
                        .HasForeignKey("DatabaseStorage.Entities.BluRayDisc", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DatabaseStorage.Entities.CdDisc", b =>
                {
                    b.HasOne("DatabaseStorage.Entities.Base.Disc", null)
                        .WithOne()
                        .HasForeignKey("DatabaseStorage.Entities.CdDisc", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DatabaseStorage.Entities.DvdDisc", b =>
                {
                    b.HasOne("DatabaseStorage.Entities.Base.Disc", null)
                        .WithOne()
                        .HasForeignKey("DatabaseStorage.Entities.DvdDisc", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DatabaseStorage.Entities.Client", b =>
                {
                    b.HasOne("DatabaseStorage.Entities.Base.Person", null)
                        .WithOne()
                        .HasForeignKey("DatabaseStorage.Entities.Client", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DatabaseStorage.Entities.Employee", b =>
                {
                    b.HasOne("DatabaseStorage.Entities.Base.Person", null)
                        .WithOne()
                        .HasForeignKey("DatabaseStorage.Entities.Employee", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DatabaseStorage.Entities.Product", b =>
                {
                    b.Navigation("Rentals");

                    b.Navigation("Sells");
                });

            modelBuilder.Entity("DatabaseStorage.Entities.Client", b =>
                {
                    b.Navigation("Rentals");
                });

            modelBuilder.Entity("DatabaseStorage.Entities.Employee", b =>
                {
                    b.Navigation("Rentals");

                    b.Navigation("Sells");
                });
#pragma warning restore 612, 618
        }
    }
}
