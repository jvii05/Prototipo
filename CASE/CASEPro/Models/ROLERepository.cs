using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CASEPro.Models
{ 
    public class ROLERepository : IROLERepository
    {
        Entities context = new Entities();

        public IQueryable<ROLE> All
        {
            get { return context.ROLEs; }
        }

        public IQueryable<ROLE> AllIncluding(params Expression<Func<ROLE, object>>[] includeProperties)
        {
            IQueryable<ROLE> query = context.ROLEs;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public ROLE Find(decimal id)
        {
            return context.ROLEs.Find(id);
        }

        public void InsertOrUpdate(ROLE role)
        {
            if (role.ID == default(decimal)) {
                // New entity
                context.ROLEs.Add(role);
            } else {
                // Existing entity
                context.Entry(role).State = EntityState.Modified;
            }
        }

        public void Delete(decimal id)
        {
            var role = context.ROLEs.Find(id);
            context.ROLEs.Remove(role);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface IROLERepository : IDisposable
    {
        IQueryable<ROLE> All { get; }
        IQueryable<ROLE> AllIncluding(params Expression<Func<ROLE, object>>[] includeProperties);
        ROLE Find(decimal id);
        void InsertOrUpdate(ROLE role);
        void Delete(decimal id);
        void Save();
    }
}