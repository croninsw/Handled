using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Handled.Models
{
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }
        [Required]
        [Display(Name = "Driver's first name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Driver's last name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Driver's license number")]
        public string LicenseNumber { get; set; }
        [Display(Name = "Insurance company")]
        public string InsuranceCompany { get; set; }
        [Display(Name = "Policy number")]
        public string InsurancePolicyNumber { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<CarDriver> CarDrivers { get; set; }

        public string FullName()
        {
            return FirstName + LastName;
        }
    }
}
