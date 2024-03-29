﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Handled.Models
{
    public class Cyclist : IdentityUser
    {
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Display(Name = "Picture")]
        public string ImagePath { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public string Height { get; set; }
        public string UserId { get; set; }

        public virtual ICollection<Bicycle> Bicycles { get; set; }
        public virtual ICollection<BicycleRider> BicycleRiders { get; set; }
        public virtual ICollection<EmergencyContact> EmergencyContacts { get; set; }
        public virtual ICollection<CyclistEmergencyContact> CyclistEmergencyContacts { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
