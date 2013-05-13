using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CASEPro.Models
{ 
    public class DETALLE_TIPOSRepository : IDETALLE_TIPOSRepository
    {
        Entities context = new Entities();

        public IQueryable<DETALLE_TIPOS> All
        {
            get { return context.DETALLE_TIPOS; }
        }

        public IQueryable<DETALLE_TIPOS> AllIncluding(params Expression<Func<DETALLE_TIPOS, object>>[] includeProperties)
        {
            IQueryable<DETALLE_TIPOS> query = context.DETALLE_TIPOS;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public DETALLE_TIPOS Find(decimal id)
        {
            return context.DETALLE_TIPOS.Find(id);
        }

        public void InsertOrUpdate(DETALLE_TIPOS detalle_tipos)
        {
            if (detalle_tipos.ID == default(decimal)) {
                // New entity
                context.DETALLE_TIPOS.Add(detalle_tipos);
            } else {
                // Existing entity
                context.Entry(detalle_tipos).State = EntityState.Modified;
            }
        }

        public void Delete(decimal id)
        {
            var detalle_tipos = context.DETALLE_TIPOS.Find(id);
            context.DETALLE_TIPOS.Remove(detalle_tipos);
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

    public interface IDETALLE_TIPOSRepository : IDisposable
    {
        IQueryable<DETALLE_TIPOS> All { get; }
        IQueryable<DETALLE_TIPOS> AllIncluding(params Expression<Func<DETALLE_TIPOS, object>>[] includeProperties);
        DETALLE_TIPOS Find(decimal id);
        void InsertOrUpdate(DETALLE_TIPOS detalle_tipos);
        void Delete(decimal id);
        void Save();
    }
}