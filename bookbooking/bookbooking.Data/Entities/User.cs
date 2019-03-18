using System;
using System.Collections.Generic;
using System.Text;

namespace bookbooking.Data.Model
{
    public class User: BaseEntity<int>
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Tc { get; set; }
        public string Phone { get; set; }
        public int BirthYear { get; set; }
    }
}
