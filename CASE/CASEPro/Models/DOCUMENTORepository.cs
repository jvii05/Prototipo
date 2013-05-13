using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CASEPro.Models
{ 
    public class DOCUMENTORepository : IDOCUMENTORepository
    {
        Entities context = new Entities();

        public IQueryable<DOCUMENTO> All
        {
            get { return context.DOCUMENTOes; }
        }

        public IQueryable<DOCUMENTO> AllIncluding(params Expression<Func<DOCUMENTO, object>>[] includeProperties)
        {
            IQueryable<DOCUMENTO> query = context.DOCUMENTOes;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public DOCUMENTO Find(decimal id)
        {
            return context.DOCUMENTOes.Find(id);
        }

        public void InsertOrUpdate(DOCUMENTO documento)
        {
            if (documento.ID == default(decimal)) {
                // New entity
                context.DOCUMENTOes.Add(documento);
            } else {
                // Existing entity
                context.Entry(documento).State = EntityState.Modified;
            }
        }

        public void Delete(decimal id)
        {
            var documento = context.DOCUMENTOes.Find(id);
            context.DOCUMENTOes.Remove(documento);
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

    public interface IDOCUMENTORepository : IDisposable
    {
        IQueryable<DOCUMENTO> All { get; }
        IQueryable<DOCUMENTO> AllIncluding(params Expression<Func<DOCUMENTO, object>>[] includeProperties);
        DOCUMENTO Find(decimal id);
        void InsertOrUpdate(DOCUMENTO documento);
        void Delete(decimal id);
        void Save();
    }
}