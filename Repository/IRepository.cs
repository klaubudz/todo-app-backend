using System;
using System.Collections.Generic;

namespace Repository
{
    public interface IRepository<T>
    {
        T Add(T entity);
        IEnumerable<T> GetAll();
        T Get(int id);
        T Edit(T entity);
        void Delete(int id);
    }
}
