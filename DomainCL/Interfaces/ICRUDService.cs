using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ICRUDService<T>
        where T : class
    {
        IEnumerable<T> GetAll();
        T GetOne(int id);
        void SetOne(T entity);
        void DelOne(int id);
    }
}
