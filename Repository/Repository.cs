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
        where T : EntityBase, new()
    {
        protected DbContext Db;
        protected DbSet<T> DbSetContext;

        public Repository(DbContext dbContext)
        {
            Db = dbContext;
            DbSetContext = Db.Set<T>();
        }
        public void DelOne(int id)
        {
            var ent = new T { Codigo = id };
            DbSetContext.Attach(ent);
            DbSetContext.Remove(ent);
            Db.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DbSetContext.AsNoTracking().ToList();
        }

        public T GetOne(int id)
        {
            return DbSetContext.Where(x => x.Codigo == id).FirstOrDefault();
        }

        public void SetOne(T entity)
        {
            if(entity.Codigo == null)
            {
                DbSetContext.Add(entity);
            }
            else
            {
                Db.Entry(entity).State = EntityState.Modified;
            }
            Db.SaveChanges();
        }
    }
}
