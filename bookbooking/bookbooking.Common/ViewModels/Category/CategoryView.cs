using System;
using System.Collections.Generic;
using System.Text;
using bookbooking.Entity.Entities;

namespace bookbooking.Common.ViewModels.Category
{
    public class CategoryView
    {
        public List<Entity.Entities.Category> Categories { get; set; }
        public Entity.Entities.Category category { get; set; }
    }
}
