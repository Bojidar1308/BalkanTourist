using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    public class ClientsReservation
    {
        public int ReservationsId { get; set; } //FK
        public virtual Reservation Reservation { get; set; }
        public int ClientId { get; set; } //FK
        public virtual Client Client { get; set; }
    }
}
