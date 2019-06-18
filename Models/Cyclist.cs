using Microsoft.AspNetCore.Identity;
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
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string ImagePath { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public string Height { get; set; }
        public virtual ICollection<Bicycle> Bicycles { get; set; }
        public virtual ICollection<BicycleRider> BicycleRiders { get; set; }
        public virtual ICollection<EmergencyContact> EmergencyContacts { get; set; }
        public virtual ICollection<CyclistEmergencyContact> CyclistEmergencyContacts { get; set; }

        public string FullName()
        {
            return FirstName + LastName;
        }
    }
}
