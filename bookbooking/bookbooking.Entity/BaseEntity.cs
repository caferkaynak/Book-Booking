using System;
using System.Collections.Generic;
using System.Text;

namespace bookbooking.Entity
{
    public class BaseEntity
    {
        //public DateTime CreateDate { get; set; } = DateTime.Now;

        //public DateTime? UpdateDate { get; set; }
    }
    public class BaseEntity<T> : BaseEntity
    {
        public T Id { get; set; }
    }
}