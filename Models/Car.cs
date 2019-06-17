using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Handled.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        [Required]
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string ManufactureYear { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public virtual ICollection<CarDriver> CarDrivers { get; set; }
    }
}
