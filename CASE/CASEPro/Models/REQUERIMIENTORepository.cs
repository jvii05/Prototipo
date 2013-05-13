using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CASEPro.Models
{ 
    public class REQUERIMIENTORepository : IREQUERIMIENTORepository
    {
        Entities context = new Entities();

        public IQueryable<REQUERIMIENTO> All
        {
            get { return context.REQUERIMIENTOes; }
        }

        public IQueryable<REQUERIMIENTO> AllIncluding(params Expression<Func<REQUERIMIENTO, object>>[] includeProperties)
        {
            IQueryable<REQUERIMIENTO> query = context.REQUERIMIENTOes;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public REQUERIMIENTO Find(decimal id)
        {
            return context.REQUERIMIENTOes.Find(id);
        }

        public void InsertOrUpdate(REQUERIMIENTO requerimiento)
        {
            if (requerimiento.ID == default(decimal)) {
                // New entity
                context.REQUERIMIENTOes.Add(requerimiento);
            } else {
                // Existing entity
                context.Entry(requerimiento).State = EntityState.Modified;
            }
        }

        public void Delete(decimal id)
        {
            var requerimiento = context.REQUERIMIENTOes.Find(id);
            context.REQUERIMIENTOes.Remove(requerimiento);
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

    public interface IREQUERIMIENTORepository : IDisposable
    {
        IQueryable<REQUERIMIENTO> All { get; }
        IQueryable<REQUERIMIENTO> AllIncluding(params Expression<Func<REQUERIMIENTO, object>>[] includeProperties);
        REQUERIMIENTO Find(decimal id);
        void InsertOrUpdate(REQUERIMIENTO requerimiento);
        void Delete(decimal id);
        void Save();
    }
}