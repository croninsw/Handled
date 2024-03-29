﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Handled.Models
{
    public class Car
    {
        [Key]
        [Display(Name = "Which car?")]
        public int CarId { get; set; }
        [Required]
        [Display(Name = "License plate number")]
        public string LicensePlate { get; set; }
        [Display(Name = "Vehicle Idenfication Number (VIN)")]
        public string VIN { get; set; }
        [Display(Name = "Manufacturer")]
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        [Display(Name = "Manufactured year")]
        public string ManufactureYear { get; set; }
        [Display(Name = "Photo")]
        public string ImagePath { get; set; }
        [Display(Name = "Who is the driver?")]
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public string UserId { get; set; }

        public virtual ICollection<CarDriver> CarDrivers { get; set; }
    }
}
