using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CASEPro.Models
{ 
    public class REQUERIMIENTO_ESTADOSRepository : IREQUERIMIENTO_ESTADOSRepository
    {
        Entities context = new Entities();

        public IQueryable<REQUERIMIENTO_ESTADOS> All
        {
            get { return context.REQUERIMIENTO_ESTADOS; }
        }

        public IQueryable<REQUERIMIENTO_ESTADOS> AllIncluding(params Expression<Func<REQUERIMIENTO_ESTADOS, object>>[] includeProperties)
        {
            IQueryable<REQUERIMIENTO_ESTADOS> query = context.REQUERIMIENTO_ESTADOS;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public REQUERIMIENTO_ESTADOS Find(decimal id)
        {
            return context.REQUERIMIENTO_ESTADOS.Find(id);
        }

        public void InsertOrUpdate(REQUERIMIENTO_ESTADOS requerimiento_estados)
        {
            if (requerimiento_estados.ID == default(decimal)) {
                // New entity
                context.REQUERIMIENTO_ESTADOS.Add(requerimiento_estados);
            } else {
                // Existing entity
                context.Entry(requerimiento_estados).State = EntityState.Modified;
            }
        }

        public void Delete(decimal id)
        {
            var requerimiento_estados = context.REQUERIMIENTO_ESTADOS.Find(id);
            context.REQUERIMIENTO_ESTADOS.Remove(requerimiento_estados);
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

    public interface IREQUERIMIENTO_ESTADOSRepository : IDisposable
    {
        IQueryable<REQUERIMIENTO_ESTADOS> All { get; }
        IQueryable<REQUERIMIENTO_ESTADOS> AllIncluding(params Expression<Func<REQUERIMIENTO_ESTADOS, object>>[] includeProperties);
        REQUERIMIENTO_ESTADOS Find(decimal id);
        void InsertOrUpdate(REQUERIMIENTO_ESTADOS requerimiento_estados);
        void Delete(decimal id);
        void Save();
    }
}