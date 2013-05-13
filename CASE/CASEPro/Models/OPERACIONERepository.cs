using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CASEPro.Models
{ 
    public class OPERACIONERepository : IOPERACIONERepository
    {
        Entities context = new Entities();

        public IQueryable<OPERACIONE> All
        {
            get { return context.OPERACIONEs; }
        }

        public IQueryable<OPERACIONE> AllIncluding(params Expression<Func<OPERACIONE, object>>[] includeProperties)
        {
            IQueryable<OPERACIONE> query = context.OPERACIONEs;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public OPERACIONE Find(decimal id)
        {
            return context.OPERACIONEs.Find(id);
        }

        public void InsertOrUpdate(OPERACIONE operacione)
        {
            if (operacione.ID == default(decimal)) {
                // New entity
                context.OPERACIONEs.Add(operacione);
            } else {
                // Existing entity
                context.Entry(operacione).State = EntityState.Modified;
            }
        }

        public void Delete(decimal id)
        {
            var operacione = context.OPERACIONEs.Find(id);
            context.OPERACIONEs.Remove(operacione);
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

    public interface IOPERACIONERepository : IDisposable
    {
        IQueryable<OPERACIONE> All { get; }
        IQueryable<OPERACIONE> AllIncluding(params Expression<Func<OPERACIONE, object>>[] includeProperties);
        OPERACIONE Find(decimal id);
        void InsertOrUpdate(OPERACIONE operacione);
        void Delete(decimal id);
        void Save();
    }
}