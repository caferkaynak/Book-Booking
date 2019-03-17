using System;
using System.Collections.Generic;
using System.Text;

namespace bookbooking.Data.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
