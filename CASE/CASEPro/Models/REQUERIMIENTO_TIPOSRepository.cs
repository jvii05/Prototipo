using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CASEPro.Models
{ 
    public class REQUERIMIENTO_TIPOSRepository : IREQUERIMIENTO_TIPOSRepository
    {
        Entities context = new Entities();

        public IQueryable<REQUERIMIENTO_TIPOS> All
        {
            get { return context.REQUERIMIENTO_TIPOS; }
        }

        public IQueryable<REQUERIMIENTO_TIPOS> AllIncluding(params Expression<Func<REQUERIMIENTO_TIPOS, object>>[] includeProperties)
        {
            IQueryable<REQUERIMIENTO_TIPOS> query = context.REQUERIMIENTO_TIPOS;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public REQUERIMIENTO_TIPOS Find(decimal id)
        {
            return context.REQUERIMIENTO_TIPOS.Find(id);
        }

        public void InsertOrUpdate(REQUERIMIENTO_TIPOS requerimiento_tipos)
        {
            if (requerimiento_tipos.ID == default(decimal)) {
                // New entity
                context.REQUERIMIENTO_TIPOS.Add(requerimiento_tipos);
            } else {
                // Existing entity
                context.Entry(requerimiento_tipos).State = EntityState.Modified;
            }
        }

        public void Delete(decimal id)
        {
            var requerimiento_tipos = context.REQUERIMIENTO_TIPOS.Find(id);
            context.REQUERIMIENTO_TIPOS.Remove(requerimiento_tipos);
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

    public interface IREQUERIMIENTO_TIPOSRepository : IDisposable
    {
        IQueryable<REQUERIMIENTO_TIPOS> All { get; }
        IQueryable<REQUERIMIENTO_TIPOS> AllIncluding(params Expression<Func<REQUERIMIENTO_TIPOS, object>>[] includeProperties);
        REQUERIMIENTO_TIPOS Find(decimal id);
        void InsertOrUpdate(REQUERIMIENTO_TIPOS requerimiento_tipos);
        void Delete(decimal id);
        void Save();
    }
}