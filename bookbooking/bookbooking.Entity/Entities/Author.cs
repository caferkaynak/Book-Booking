using System.ComponentModel.DataAnnotations;

namespace bookbooking.Entity.Entities
{
    public class Author :BaseEntity<int>
    {
        [Required]
        public string Name { get; set; }
    }
}
