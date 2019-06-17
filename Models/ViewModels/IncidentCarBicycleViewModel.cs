using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Handled.Models.ViewModels
{
    public class IncidentCarBicycleViewModel
    {
        public int IncidentCarBicycleViewModelId { get; set; }
        public Car Car { get; set; }
        public Driver Driver { get; set; }
        public Bicycle Bicycle { get; set; }
        public Cyclist Cyclist { get; set; }
        public int CarDriverId { get; set; }
        public CarDriver CarDriver { get; set; }
        public int BicycleRiderId { get; set; }
        public BicycleRider BicycleRider { get; set; }
        public Incident Incident { get; set; }
    }
}
