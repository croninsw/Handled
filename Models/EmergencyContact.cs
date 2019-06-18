using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Handled.Models
{
    public class EmergencyContact
    {

        [Key]
        public int EmergencyContactId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Relation { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CyclistId { get; set; }
        public virtual ICollection<CyclistEmergencyContact> CyclistEmergencyContacts { get; set; }

        public string FullName()
        {
            return FirstName + LastName;
        }
    }
}
