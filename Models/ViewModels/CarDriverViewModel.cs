using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Handled.Models.ViewModels
{
    public class CarDriverViewModel
    {
        public int CarDriverViewModelId { get; set; }
        public Car Car { get; set; }
        public Driver Driver { get; set; }
        public CarDriver CarDriver { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
