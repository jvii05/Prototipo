using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CASEPro.Models
{ 
    public class CASO_USO_DETALLESRepository : ICASO_USO_DETALLESRepository
    {
        Entities context = new Entities();

        public IQueryable<CASO_USO_DETALLES> All
        {
            get { return context.CASO_USO_DETALLES; }
        }

        public IQueryable<CASO_USO_DETALLES> AllIncluding(params Expression<Func<CASO_USO_DETALLES, object>>[] includeProperties)
        {
            IQueryable<CASO_USO_DETALLES> query = context.CASO_USO_DETALLES;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public CASO_USO_DETALLES Find(decimal id)
        {
            return context.CASO_USO_DETALLES.Find(id);
        }

        public void InsertOrUpdate(CASO_USO_DETALLES caso_uso_detalles)
        {
            if (caso_uso_detalles.ID == default(decimal)) {
                // New entity
                context.CASO_USO_DETALLES.Add(caso_uso_detalles);
            } else {
                // Existing entity
                context.Entry(caso_uso_detalles).State = EntityState.Modified;
            }
        }

        public void Delete(decimal id)
        {
            var caso_uso_detalles = context.CASO_USO_DETALLES.Find(id);
            context.CASO_USO_DETALLES.Remove(caso_uso_detalles);
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

    public interface ICASO_USO_DETALLESRepository : IDisposable
    {
        IQueryable<CASO_USO_DETALLES> All { get; }
        IQueryable<CASO_USO_DETALLES> AllIncluding(params Expression<Func<CASO_USO_DETALLES, object>>[] includeProperties);
        CASO_USO_DETALLES Find(decimal id);
        void InsertOrUpdate(CASO_USO_DETALLES caso_uso_detalles);
        void Delete(decimal id);
        void Save();
    }
}