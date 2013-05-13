using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CASEPro.Models
{ 
    public class REQUERIMIENTO_CATEGORIASRepository : IREQUERIMIENTO_CATEGORIASRepository
    {
        Entities context = new Entities();

        public IQueryable<REQUERIMIENTO_CATEGORIAS> All
        {
            get { return context.REQUERIMIENTO_CATEGORIAS; }
        }

        public IQueryable<REQUERIMIENTO_CATEGORIAS> AllIncluding(params Expression<Func<REQUERIMIENTO_CATEGORIAS, object>>[] includeProperties)
        {
            IQueryable<REQUERIMIENTO_CATEGORIAS> query = context.REQUERIMIENTO_CATEGORIAS;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public REQUERIMIENTO_CATEGORIAS Find(decimal id)
        {
            return context.REQUERIMIENTO_CATEGORIAS.Find(id);
        }

        public void InsertOrUpdate(REQUERIMIENTO_CATEGORIAS requerimiento_categorias)
        {
            if (requerimiento_categorias.ID == default(decimal)) {
                // New entity
                context.REQUERIMIENTO_CATEGORIAS.Add(requerimiento_categorias);
            } else {
                // Existing entity
                context.Entry(requerimiento_categorias).State = EntityState.Modified;
            }
        }

        public void Delete(decimal id)
        {
            var requerimiento_categorias = context.REQUERIMIENTO_CATEGORIAS.Find(id);
            context.REQUERIMIENTO_CATEGORIAS.Remove(requerimiento_categorias);
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

    public interface IREQUERIMIENTO_CATEGORIASRepository : IDisposable
    {
        IQueryable<REQUERIMIENTO_CATEGORIAS> All { get; }
        IQueryable<REQUERIMIENTO_CATEGORIAS> AllIncluding(params Expression<Func<REQUERIMIENTO_CATEGORIAS, object>>[] includeProperties);
        REQUERIMIENTO_CATEGORIAS Find(decimal id);
        void InsertOrUpdate(REQUERIMIENTO_CATEGORIAS requerimiento_categorias);
        void Delete(decimal id);
        void Save();
    }
}