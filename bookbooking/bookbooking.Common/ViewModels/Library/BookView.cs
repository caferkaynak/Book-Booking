using bookbooking.Entity.Entities;
using System.Collections.Generic;

namespace bookbooking.Common.ViewModels.Library
{
    public class BookView
    {
        public List<Book> Books { get; set; }
        public Book Book { get; set; }
        public List<Entity.Entities.Category> Categories { get; set; }
        public List<Author> Authors { get; set; }
        public Author Author { get; set; }
    }
}
