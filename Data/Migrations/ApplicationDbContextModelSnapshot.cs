﻿// <auto-generated />
using System;
using Handled.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Handled.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("CyclistId");

                    b.Property<string>("Make");

                    b.Property<string>("ManufactureYear");

                    b.Property<string>("Model");

                    b.Property<string>("VIN")
                        .IsRequired();

                    b.HasKey("BicycleId");

                    b.HasIndex("CyclistId")
                        .IsUnique();

                    b.ToTable("Bicycle");
                });

            modelBuilder.Entity("Handled.Models.BicycleRider", b =>
                {
                    b.Property<int>("BicycleRiderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BicycleId");

                    b.Property<int>("CyclistId");

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

                    b.Property<int?>("CarDriverViewModelId");

                    b.Property<string>("Color");

                    b.Property<int>("DriverId");

                    b.Property<string>("Make");

                    b.Property<string>("ManufactureYear");

                    b.Property<string>("Model");

                    b.Property<string>("VIN")
                        .IsRequired();

                    b.HasKey("CarId");

                    b.HasIndex("CarDriverViewModelId");

                    b.HasIndex("DriverId")
                        .IsUnique();

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
                    b.Property<int>("CyclistId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("Height");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<double>("Weight");

                    b.HasKey("CyclistId");

                    b.ToTable("Cyclist");
                });

            modelBuilder.Entity("Handled.Models.CyclistEmergencyContact", b =>
                {
                    b.Property<int>("CyclistEmergencyContactId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CyclistId");

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

                    b.Property<int?>("CarDriverViewModelId");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("InsuranceCompany");

                    b.Property<string>("InsurancePolicyNumber");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("LicenseNumber")
                        .IsRequired();

                    b.HasKey("DriverId");

                    b.HasIndex("CarDriverViewModelId");

                    b.ToTable("Driver");
                });

            modelBuilder.Entity("Handled.Models.EmergencyContact", b =>
                {
                    b.Property<int>("EmergencyContactId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CyclistId");

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

                    b.ToTable("EmergencyContact");
                });

            modelBuilder.Entity("Handled.Models.Incident", b =>
                {
                    b.Property<int>("IncidentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BicycleRiderId");

                    b.Property<int>("CarDriverId");

                    b.Property<DateTime>("IncidentDate");

                    b.HasKey("IncidentId");

                    b.HasIndex("BicycleRiderId");

                    b.HasIndex("CarDriverId");

                    b.ToTable("Incident");
                });

            modelBuilder.Entity("Handled.Models.ViewModels.CarDriverViewModel", b =>
                {
                    b.Property<int>("CarDriverViewModelId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarDriverId");

                    b.Property<int?>("CarId");

                    b.Property<int?>("DriverId");

                    b.HasKey("CarDriverViewModelId");

                    b.HasIndex("CarDriverId");

                    b.HasIndex("CarId");

                    b.HasIndex("DriverId");

                    b.ToTable("CarDriverViewModel");
                });

            modelBuilder.Entity("Handled.Models.ViewModels.IncidentCarBicycleViewModel", b =>
                {
                    b.Property<int>("IncidentCarBicycleViewModelId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BicycleId");

                    b.Property<int>("BicycleRiderId");

                    b.Property<int>("CarDriverId");

                    b.Property<int?>("CarId");

                    b.Property<int?>("CyclistId");

                    b.Property<int?>("DriverId");

                    b.Property<int?>("IncidentId");

                    b.HasKey("IncidentCarBicycleViewModelId");

                    b.HasIndex("BicycleId");

                    b.HasIndex("BicycleRiderId");

                    b.HasIndex("CarDriverId");

                    b.HasIndex("CarId");

                    b.HasIndex("CyclistId");

                    b.HasIndex("DriverId");

                    b.HasIndex("IncidentId");

                    b.ToTable("IncidentCarBicycleViewModel");
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

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

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
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
                        .WithOne("Bicycle")
                        .HasForeignKey("Handled.Models.Bicycle", "CyclistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Handled.Models.BicycleRider", b =>
                {
                    b.HasOne("Handled.Models.Bicycle", "Bicycle")
                        .WithMany("BicycleRiders")
                        .HasForeignKey("BicycleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Handled.Models.Cyclist", "Cyclist")
                        .WithMany("BicycleRiders")
                        .HasForeignKey("CyclistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Handled.Models.Car", b =>
                {
                    b.HasOne("Handled.Models.ViewModels.CarDriverViewModel")
                        .WithMany("Cars")
                        .HasForeignKey("CarDriverViewModelId");

                    b.HasOne("Handled.Models.Driver", "Driver")
                        .WithOne("Car")
                        .HasForeignKey("Handled.Models.Car", "DriverId")
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
                        .HasForeignKey("CyclistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Handled.Models.EmergencyContact", "EmergencyContact")
                        .WithMany("CyclistEmergencyContacts")
                        .HasForeignKey("EmergencyContactId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Handled.Models.Driver", b =>
                {
                    b.HasOne("Handled.Models.ViewModels.CarDriverViewModel")
                        .WithMany("Drivers")
                        .HasForeignKey("CarDriverViewModelId");
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

            modelBuilder.Entity("Handled.Models.ViewModels.CarDriverViewModel", b =>
                {
                    b.HasOne("Handled.Models.CarDriver", "CarDriver")
                        .WithMany()
                        .HasForeignKey("CarDriverId");

                    b.HasOne("Handled.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId");

                    b.HasOne("Handled.Models.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId");
                });

            modelBuilder.Entity("Handled.Models.ViewModels.IncidentCarBicycleViewModel", b =>
                {
                    b.HasOne("Handled.Models.Bicycle", "Bicycle")
                        .WithMany()
                        .HasForeignKey("BicycleId");

                    b.HasOne("Handled.Models.BicycleRider", "BicycleRider")
                        .WithMany()
                        .HasForeignKey("BicycleRiderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Handled.Models.CarDriver", "CarDriver")
                        .WithMany()
                        .HasForeignKey("CarDriverId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Handled.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId");

                    b.HasOne("Handled.Models.Cyclist", "Cyclist")
                        .WithMany()
                        .HasForeignKey("CyclistId");

                    b.HasOne("Handled.Models.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId");

                    b.HasOne("Handled.Models.Incident", "Incident")
                        .WithMany()
                        .HasForeignKey("IncidentId");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
