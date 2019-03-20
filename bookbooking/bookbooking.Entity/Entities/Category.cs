using System;
using System.Collections.Generic;
using System.Text;

namespace bookbooking.Entity.Model
{
    public class Category:BaseEntity<int>
    {
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
