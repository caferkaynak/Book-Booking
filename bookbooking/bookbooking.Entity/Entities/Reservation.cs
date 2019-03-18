﻿using System;
using System.Collections.Generic;
using System.Text;

namespace bookbooking.Entity.Model
{
    public class Reservation: BaseEntity<int>
    {
        public int UserId { get; set; }
        public virtual User User{ get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public DateTime StartReservationTime { get; set; }
        public DateTime FinishReservationTime { get; set; }
    }
}