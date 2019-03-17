using System;
using System.Collections.Generic;
using System.Text;

namespace bookbooking.Data.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Tc { get; set; }
        public string Phone { get; set; }
        public int BirthYear { get; set; }
    }
}
