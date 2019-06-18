using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Handled.Models
{
    public class CyclistEmergencyContact
    {
        [Key]
        public int CyclistEmergencyContactId { get; set; }
        public string CyclistId { get; set; }
        public Cyclist Cyclist { get; set; }
        public int EmergencyContactId { get; set; }
        public EmergencyContact EmergencyContact { get; set; }
    }
}
