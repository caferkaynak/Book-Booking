using System;
using System.Collections.Generic;
using System.Text;

namespace bookbooking.Data.Model
{
    public class Category:BaseEntity<int>
    {
        public string Name { get; set; }
    }
}
