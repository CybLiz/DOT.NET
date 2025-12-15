using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Repository
{
    internal interface IRepository<T, Tid>
    {
        T? Add(T entity);
        T? GetById(Tid id);
        List<T> GetAll();
        T? Update(Tid id, T entity);
        bool Delete(Tid id);
    }
}
