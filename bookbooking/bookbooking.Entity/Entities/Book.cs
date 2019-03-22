using System;
using System.Collections.Generic;
using System.Text;

namespace bookbooking.Entity.Entities
{
    public class Book:BaseEntity<int>
    {
        public string Name { get; set; }
        public string ImageName { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
