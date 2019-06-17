using System;
using System.Collections.Generic;
using System.Text;
using Handled.Models;
using Handled.Models.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Handled.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Car> Car { get; set; }
        public DbSet<Driver> Driver { get; set; }
        public DbSet<CarDriver> CarDriver { get; set; }
        public DbSet<Bicycle> Bicycle { get; set; }
        public DbSet<Cyclist> Cyclist { get; set; }
        public DbSet<BicycleRider> BicycleRider { get; set; }
        public DbSet<EmergencyContact> EmergencyContact { get; set; }
        public DbSet<CyclistEmergencyContact> CyclistEmergencyContact { get; set; }
        public DbSet<Incident> Incident { get; set; }
        public DbSet<CarDriverViewModel> CarDriverViewModel { get; set; }
        public DbSet<IncidentCarBicycleViewModel> IncidentCarBicycleViewModel { get; set; }
    }
}
