using bookbooking.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace bookbooking.Data
{
    public class bookbookingContext : DbContext
    {
        public bookbookingContext(DbContextOptions<bookbookingContext> options)
        : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
