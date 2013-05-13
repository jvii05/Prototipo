using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CASEPro.Models
{ 
    public class PROYECTO_DETALLESRepository : IPROYECTO_DETALLESRepository
    {
        Entities context = new Entities();

        public IQueryable<PROYECTO_DETALLES> All
        {
            get { return context.PROYECTO_DETALLES; }
        }

        public IQueryable<PROYECTO_DETALLES> AllIncluding(params Expression<Func<PROYECTO_DETALLES, object>>[] includeProperties)
        {
            IQueryable<PROYECTO_DETALLES> query = context.PROYECTO_DETALLES;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public PROYECTO_DETALLES Find(decimal id)
        {
            return context.PROYECTO_DETALLES.Find(id);
        }

        public void InsertOrUpdate(PROYECTO_DETALLES proyecto_detalles)
        {
            if (proyecto_detalles.ID == default(decimal)) {
                // New entity
                context.PROYECTO_DETALLES.Add(proyecto_detalles);
            } else {
                // Existing entity
                context.Entry(proyecto_detalles).State = EntityState.Modified;
            }
        }

        public void Delete(decimal id)
        {
            var proyecto_detalles = context.PROYECTO_DETALLES.Find(id);
            context.PROYECTO_DETALLES.Remove(proyecto_detalles);
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

    public interface IPROYECTO_DETALLESRepository : IDisposable
    {
        IQueryable<PROYECTO_DETALLES> All { get; }
        IQueryable<PROYECTO_DETALLES> AllIncluding(params Expression<Func<PROYECTO_DETALLES, object>>[] includeProperties);
        PROYECTO_DETALLES Find(decimal id);
        void InsertOrUpdate(PROYECTO_DETALLES proyecto_detalles);
        void Delete(decimal id);
        void Save();
    }
}