using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CASE.Models
{ 
    public class USERRepository : IUSERRepository
    {
        CASEEntities context = new CASEEntities();

        public IQueryable<USER> All
        {
            get { return context.USERs; }
        }

        public IQueryable<USER> AllIncluding(params Expression<Func<USER, object>>[] includeProperties)
        {
            IQueryable<USER> query = context.USERs;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public USER Find(decimal id)
        {
            return context.USERs.Find(id);
        }

        public void InsertOrUpdate(USER user)
        {
            if (user.ID == default(decimal)) {
                // New entity
                context.USERs.Add(user);
            } else {
                // Existing entity
                context.Entry(user).State = EntityState.Modified;
            }
        }

        public void Delete(decimal id)
        {
            var user = context.USERs.Find(id);
            context.USERs.Remove(user);
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

    public interface IUSERRepository : IDisposable
    {
        IQueryable<USER> All { get; }
        IQueryable<USER> AllIncluding(params Expression<Func<USER, object>>[] includeProperties);
        USER Find(decimal id);
        void InsertOrUpdate(USER user);
        void Delete(decimal id);
        void Save();
    }
}