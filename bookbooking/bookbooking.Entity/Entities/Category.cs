using System.ComponentModel.DataAnnotations;

namespace bookbooking.Entity.Entities
{
    public class Category:BaseEntity<int>
    {   [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
