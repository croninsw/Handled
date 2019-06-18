﻿// <auto-generated />
using System;
using Handled.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Handled.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190618201620_cyclistid")]
    partial class cyclistid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Handled.Models.Bicycle", b =>
                {
                    b.Property<int>("BicycleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color");

                    b.Property<string>("CyclistId");

                    b.Property<string>("ImagePath");

                    b.Property<string>("Make");

                    b.Property<string>("ManufactureYear");

                    b.Property<string>("Model");

                    b.Property<string>("VIN")
                        .IsRequired();

                    b.HasKey("BicycleId");

                    b.HasIndex("CyclistId");

                    b.ToTable("Bicycle");
                });

            modelBuilder.Entity("Handled.Models.BicycleRider", b =>
                {
                    b.Property<int>("BicycleRiderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BicycleId");

                    b.Property<string>("CyclistId");

                    b.HasKey("BicycleRiderId");

                    b.HasIndex("BicycleId");

                    b.HasIndex("CyclistId");

                    b.ToTable("BicycleRider");
                });

            modelBuilder.Entity("Handled.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color");

                    b.Property<int>("DriverId");

                    b.Property<string>("ImagePath");

                    b.Property<string>("LicensePlate")
                        .IsRequired();

                    b.Property<string>("Make");

                    b.Property<string>("ManufactureYear");

                    b.Property<string>("Model");

                    b.Property<string>("VIN");

                    b.HasKey("CarId");

                    b.HasIndex("DriverId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("Handled.Models.CarDriver", b =>
                {
                    b.Property<int>("CarDriverId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId");

                    b.Property<int>("DriverId");

                    b.HasKey("CarDriverId");

                    b.HasIndex("CarId");

                    b.HasIndex("DriverId");

                    b.ToTable("CarDriver");
                });

            modelBuilder.Entity("Handled.Models.Cyclist", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int>("Age");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("Height");

                    b.Property<string>("ImagePath");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<double>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Handled.Models.CyclistEmergencyContact", b =>
                {
                    b.Property<int>("CyclistEmergencyContactId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CyclistId");

                    b.Property<int>("EmergencyContactId");

                    b.HasKey("CyclistEmergencyContactId");

                    b.HasIndex("CyclistId");

                    b.HasIndex("EmergencyContactId");

                    b.ToTable("CyclistEmergencyContact");
                });

            modelBuilder.Entity("Handled.Models.Driver", b =>
                {
                    b.Property<int>("DriverId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("InsuranceCompany");

                    b.Property<string>("InsurancePolicyNumber");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("LicenseNumber")
                        .IsRequired();

                    b.HasKey("DriverId");

                    b.ToTable("Driver");
                });

            modelBuilder.Entity("Handled.Models.EmergencyContact", b =>
                {
                    b.Property<int>("EmergencyContactId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CyclistId");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<string>("Relation")
                        .IsRequired();

                    b.HasKey("EmergencyContactId");

                    b.HasIndex("CyclistId");

                    b.ToTable("EmergencyContact");
                });

            modelBuilder.Entity("Handled.Models.Incident", b =>
                {
                    b.Property<int>("IncidentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BicycleRiderId");

                    b.Property<int>("CarDriverId");

                    b.Property<string>("ImagePath");

                    b.Property<DateTime>("IncidentDate");

                    b.HasKey("IncidentId");

                    b.HasIndex("BicycleRiderId");

                    b.HasIndex("CarDriverId");

                    b.ToTable("Incident");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Handled.Models.Bicycle", b =>
                {
                    b.HasOne("Handled.Models.Cyclist", "Cyclist")
                        .WithMany("Bicycles")
                        .HasForeignKey("CyclistId");
                });

            modelBuilder.Entity("Handled.Models.BicycleRider", b =>
                {
                    b.HasOne("Handled.Models.Bicycle", "Bicycle")
                        .WithMany("BicycleRiders")
                        .HasForeignKey("BicycleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Handled.Models.Cyclist", "Cyclist")
                        .WithMany("BicycleRiders")
                        .HasForeignKey("CyclistId");
                });

            modelBuilder.Entity("Handled.Models.Car", b =>
                {
                    b.HasOne("Handled.Models.Driver", "Driver")
                        .WithMany("Cars")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Handled.Models.CarDriver", b =>
                {
                    b.HasOne("Handled.Models.Car", "Car")
                        .WithMany("CarDrivers")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Handled.Models.Driver", "Driver")
                        .WithMany("CarDrivers")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Handled.Models.CyclistEmergencyContact", b =>
                {
                    b.HasOne("Handled.Models.Cyclist", "Cyclist")
                        .WithMany("CyclistEmergencyContacts")
                        .HasForeignKey("CyclistId");

                    b.HasOne("Handled.Models.EmergencyContact", "EmergencyContact")
                        .WithMany("CyclistEmergencyContacts")
                        .HasForeignKey("EmergencyContactId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Handled.Models.EmergencyContact", b =>
                {
                    b.HasOne("Handled.Models.Cyclist")
                        .WithMany("EmergencyContacts")
                        .HasForeignKey("CyclistId");
                });

            modelBuilder.Entity("Handled.Models.Incident", b =>
                {
                    b.HasOne("Handled.Models.BicycleRider", "BicycleRider")
                        .WithMany("Incidents")
                        .HasForeignKey("BicycleRiderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Handled.Models.CarDriver", "CarDriver")
                        .WithMany("Incidents")
                        .HasForeignKey("CarDriverId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Handled.Models.Cyclist")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Handled.Models.Cyclist")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Handled.Models.Cyclist")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Handled.Models.Cyclist")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
