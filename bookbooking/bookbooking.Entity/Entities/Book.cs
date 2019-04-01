using System;
using System.ComponentModel.DataAnnotations;

namespace bookbooking.Entity.Entities
{
    public class Book:BaseEntity<int>
    {
        [Required]
        public string Name { get; set; }
        public string ImageName { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [Required]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime IsAvailableTime { get; set; }
    }
}
