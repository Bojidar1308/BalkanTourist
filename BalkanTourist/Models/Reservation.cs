using System;
using System.Collections.Generic;

namespace BalkanTourist
{
    public class Reservation
    {
        public int Id { get; set; } //PK
        public int RoomId { get; set; } //FK
        public string UserID { get; set; } //FK
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Breakfast { get; set; }
        public bool AllInclusive { get; set; }
        public double TotalSum { get; set; }
        public virtual User User { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<ClientsReservation> ClientsReservations { get; set; }
    }
}
