using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CASEPro.Models
{ 
    public class USUARIORepository : IUSUARIORepository
    {
        Entities context = new Entities();

        public IQueryable<USUARIO> All
        {
            get { return context.USUARIOs; }
        }

        public IQueryable<USUARIO> AllIncluding(params Expression<Func<USUARIO, object>>[] includeProperties)
        {
            IQueryable<USUARIO> query = context.USUARIOs;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public USUARIO Find(decimal id)
        {
            return context.USUARIOs.Find(id);
        }

        public void InsertOrUpdate(USUARIO usuario)
        {
            if (usuario.ID == default(decimal)) {
                // New entity
                context.USUARIOs.Add(usuario);
            } else {
                // Existing entity
                context.Entry(usuario).State = EntityState.Modified;
            }
        }

        public void Delete(decimal id)
        {
            var usuario = context.USUARIOs.Find(id);
            context.USUARIOs.Remove(usuario);
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

    public interface IUSUARIORepository : IDisposable
    {
        IQueryable<USUARIO> All { get; }
        IQueryable<USUARIO> AllIncluding(params Expression<Func<USUARIO, object>>[] includeProperties);
        USUARIO Find(decimal id);
        void InsertOrUpdate(USUARIO usuario);
        void Delete(decimal id);
        void Save();
    }
}