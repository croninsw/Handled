using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Handled.Models
{
    public class Bicycle
    {
        [Key]
        public int BicycleId { get; set; }
        [Required]
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string ManufactureYear { get; set; }
        public string ImagePath { get; set; }
        public int CyclistId { get; set; }
        public Cyclist Cyclist { get; set; }
        public virtual ICollection<BicycleRider> BicycleRiders { get; set; }
    }
}
