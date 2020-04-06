using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetOne(int id);
        void SetOne(TEntity entity);
        void DelOne(int id);
    }
}
