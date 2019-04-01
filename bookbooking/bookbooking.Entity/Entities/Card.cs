using System;
using System.Collections.Generic;
using System.Text;

namespace bookbooking.Entity.Entities
{
    public class Card:BaseEntity<int>
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
