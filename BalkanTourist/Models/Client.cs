using System.Collections.Generic;

namespace BalkanTourist
{
    public class Client
    {
        public int Id { get; set; } // PK
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool Adult { get; set; }
        public virtual ICollection<ClientsReservation> ClientsReservations { get; set; }
    }
}
