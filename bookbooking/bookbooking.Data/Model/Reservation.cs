using System;
using System.Collections.Generic;
using System.Text;

namespace bookbooking.Data.Model
{
    public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User{ get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public DateTime StartReservationTime { get; set; }
        public DateTime FinishReservationTime { get; set; }
    }
}
