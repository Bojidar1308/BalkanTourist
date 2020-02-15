using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    public class User
    {
        public int Id { get; set; } //PK
        public string Username { get; set; }
        public string Password { get; set; }
        public string  Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string EGN { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime AssignmentDate { get; set; }
        public bool Active { get; set; }
        public DateTime RetirementDate { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
