using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BalkanTourist
{
    public class User : IdentityUser
    {
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string EGN { get; set; }
        public DateTime AssignmentDate { get; set; }
        public bool Active { get; set; }
        public DateTime RetirementDate { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
