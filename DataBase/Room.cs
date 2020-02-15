using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    public class Room
    {
        public int Id { get; set; } //PK
        public int Capacity { get; set; }
        public string Type { get; set; }
        public bool IsFree { get; set; }
        public double PriceAdult { get; set; }
        public double PriceKid { get; set; }
        public int RoomNumber { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
