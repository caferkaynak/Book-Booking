using System;
using System.Collections.Generic;
using System.Text;

namespace bookbooking.Data
{
    public interface IRepository<T> where T: BaseEntity
    {

    }
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

    }
}
