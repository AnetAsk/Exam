using System;
using System.Collections.Generic;

namespace Domain.DataAccess.Services
{
    public interface IRepository<T> where T : class
    {
        bool Add(T entity);
        bool Edit(T entity);
        bool Delete(T entity);
        T Get(Guid id);
        IList<T> GetAll();
    }
}
