﻿using System.ComponentModel.DataAnnotations;

namespace bookbooking.Entity.Entities
{
    public class Category:BaseEntity<int>
    {   [Required]
        public string Name { get; set; }
    }
}
