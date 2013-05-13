using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CASEPro.Models
{ 
    public class REQUERIMIENTO_DETALLESRepository : IREQUERIMIENTO_DETALLESRepository
    {
        Entities context = new Entities();

        public IQueryable<REQUERIMIENTO_DETALLES> All
        {
            get { return context.REQUERIMIENTO_DETALLES; }
        }

        public IQueryable<REQUERIMIENTO_DETALLES> AllIncluding(params Expression<Func<REQUERIMIENTO_DETALLES, object>>[] includeProperties)
        {
            IQueryable<REQUERIMIENTO_DETALLES> query = context.REQUERIMIENTO_DETALLES;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public REQUERIMIENTO_DETALLES Find(decimal id)
        {
            return context.REQUERIMIENTO_DETALLES.Find(id);
        }

        public void InsertOrUpdate(REQUERIMIENTO_DETALLES requerimiento_detalles)
        {
            if (requerimiento_detalles.ID == default(decimal)) {
                // New entity
                context.REQUERIMIENTO_DETALLES.Add(requerimiento_detalles);
            } else {
                // Existing entity
                context.Entry(requerimiento_detalles).State = EntityState.Modified;
            }
        }

        public void Delete(decimal id)
        {
            var requerimiento_detalles = context.REQUERIMIENTO_DETALLES.Find(id);
            context.REQUERIMIENTO_DETALLES.Remove(requerimiento_detalles);
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

    public interface IREQUERIMIENTO_DETALLESRepository : IDisposable
    {
        IQueryable<REQUERIMIENTO_DETALLES> All { get; }
        IQueryable<REQUERIMIENTO_DETALLES> AllIncluding(params Expression<Func<REQUERIMIENTO_DETALLES, object>>[] includeProperties);
        REQUERIMIENTO_DETALLES Find(decimal id);
        void InsertOrUpdate(REQUERIMIENTO_DETALLES requerimiento_detalles);
        void Delete(decimal id);
        void Save();
    }
}