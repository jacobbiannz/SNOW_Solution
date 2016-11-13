using SNOW_Solution.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SNOW_Solution.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected CompanyDbContext db = null;
        protected DbSet<T> table = null;

        public GenericRepository()
        {
            this.db = new CompanyDbContext();
            table = db.Set<T>();
        }

        public GenericRepository(CompanyDbContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }

        public virtual IEnumerable<T> SelectAll()
        {
            return table.ToList();
        }

        public virtual T SelectByID(object id)
        {
            return table.Find(id);
        }

        public virtual void Insert(T obj)
        {
            table.Add(obj);
        }

        public virtual void Update(T obj)
        {
            table.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public virtual void Save()
        {
            db.SaveChanges();
        }
    }
}