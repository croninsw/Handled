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
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string LicenseNumber { get; set; }
        public string InsuranceCompany { get; set; }
        public string InsurancePolicyNumber { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<CarDriver> CarDrivers { get; set; }

        public string FullName()
        {
            return FirstName + LastName;
        }
    }
}
