using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CASEPro.Models
{ 
    public class PROYECTORepository : IPROYECTORepository
    {
        Entities context = new Entities();

        public IQueryable<PROYECTO> All
        {
            get { return context.PROYECTOes; }
        }

        public IQueryable<PROYECTO> AllIncluding(params Expression<Func<PROYECTO, object>>[] includeProperties)
        {
            IQueryable<PROYECTO> query = context.PROYECTOes;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public PROYECTO Find(decimal id)
        {
            return context.PROYECTOes.Find(id);
        }

        public void InsertOrUpdate(PROYECTO proyecto)
        {
            if (proyecto.ID == default(decimal)) {
                // New entity
                context.PROYECTOes.Add(proyecto);
            } else {
                // Existing entity
                context.Entry(proyecto).State = EntityState.Modified;
            }
        }

        public void Delete(decimal id)
        {
            var proyecto = context.PROYECTOes.Find(id);
            context.PROYECTOes.Remove(proyecto);
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

    public interface IPROYECTORepository : IDisposable
    {
        IQueryable<PROYECTO> All { get; }
        IQueryable<PROYECTO> AllIncluding(params Expression<Func<PROYECTO, object>>[] includeProperties);
        PROYECTO Find(decimal id);
        void InsertOrUpdate(PROYECTO proyecto);
        void Delete(decimal id);
        void Save();
    }
}