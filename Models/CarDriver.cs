﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Handled.Models
{
    public class CarDriver
    {
        [Key]
        public int CarDriverId { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public virtual ICollection<Incident> Incidents { get; set; }
    }
}
