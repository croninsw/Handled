using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Handled.Models
{
    public class Incident
    {
        [Key]
        public int IncidentId { get; set; }
        public int BicycleRiderId { get; set; }
        public BicycleRider BicycleRider { get; set; }
        public int CarDriverId { get; set; }
        public CarDriver CarDriver { get; set; }
        public string ImagePath { get; set; }
        public DateTime IncidentDate { get; set; }
    }
}
