using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CASEPro.Models
{ 
    public class CASOS_USOSRepository : ICASOS_USOSRepository
    {
        Entities context = new Entities();

        public IQueryable<CASOS_USOS> All
        {
            get { return context.CASOS_USOS; }
        }

        public IQueryable<CASOS_USOS> AllIncluding(params Expression<Func<CASOS_USOS, object>>[] includeProperties)
        {
            IQueryable<CASOS_USOS> query = context.CASOS_USOS;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public CASOS_USOS Find(decimal id)
        {
            return context.CASOS_USOS.Find(id);
        }

        public void InsertOrUpdate(CASOS_USOS casos_usos)
        {
            if (casos_usos.ID == default(decimal)) {
                // New entity
                context.CASOS_USOS.Add(casos_usos);
            } else {
                // Existing entity
                context.Entry(casos_usos).State = EntityState.Modified;
            }
        }

        public void Delete(decimal id)
        {
            var casos_usos = context.CASOS_USOS.Find(id);
            context.CASOS_USOS.Remove(casos_usos);
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

    public interface ICASOS_USOSRepository : IDisposable
    {
        IQueryable<CASOS_USOS> All { get; }
        IQueryable<CASOS_USOS> AllIncluding(params Expression<Func<CASOS_USOS, object>>[] includeProperties);
        CASOS_USOS Find(decimal id);
        void InsertOrUpdate(CASOS_USOS casos_usos);
        void Delete(decimal id);
        void Save();
    }
}