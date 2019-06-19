using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Handled.Models
{
    public class Incident
    {
        [Key]
        public int IncidentId { get; set; }
        [Display(Name = "Bicycle")]
        public int BicycleRiderId { get; set; }
        public BicycleRider BicycleRider { get; set; }
        [Display(Name = "Car Driver")]
        public int CarDriverId { get; set; }
        public CarDriver CarDriver { get; set; }
        [Display(Name = "Photo")]
        public string ImagePath { get; set; }
        [Display(Name = "Date of Incident")]
        public DateTime IncidentDate { get; set; }
        public string UserId { get; set; }

    }
}
