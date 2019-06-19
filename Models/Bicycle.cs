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
        [Display(Name = "Vehicle Identification Number (VIN)")]
        public string VIN { get; set; }
        [Display(Name = "Bicycle manufacturer")]
        public string Make { get; set; }
        [Display(Name = "Model")]
        public string Model { get; set; }
        public string Color { get; set; }
        [Display(Name = "Manufactured year")]
        public string ManufactureYear { get; set; }
        [Display(Name = "Photo")]
        public string ImagePath { get; set; }
        [Display(Name = "Cyclist")]
        public string CyclistId { get; set; }
        public Cyclist Cyclist { get; set; }
        public virtual ICollection<BicycleRider> BicycleRiders { get; set; }
    }
}
