using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Handled.Models
{
    public class BicycleRider
    {
        [Key]
        public int BicycleRiderId { get; set; }
        public string CyclistId { get; set; }
        public Cyclist Cyclist { get; set; }
        [Display(Name = "Which bike?")]
        public int BicycleId { get; set; }
        public Bicycle Bicycle { get; set; }
        public string UserId { get; set; }

        public virtual ICollection<Incident> Incidents { get; set; }
    }
}
