using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UdemySalesWebApp.Domain.Entities;

namespace Repository
{
    public abstract class Repository<T> : DbContext, IRepository<T>
        where T : class, new()
    {
        DbContext Db;
        DbSet<T> DbSetContext;

        public Repository(DbContext dbContext)
        {
            Db = dbContext;
            DbSetContext = Db.Set<T>();
        }
        public void DelOne(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return DbSetContext.AsNoTracking().ToList();
        }

        public T GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public void SetOne(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
