using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCTest.Models;

namespace MVCTest.Models
{
    public class EFGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        AppDbContext context;
        DbSet<TEntity> dbset;
        public EFGenericRepository(AppDbContext ctx)
        {
            context = ctx;
      
            dbset = ctx.Set<TEntity>();
        }
        public IQueryable<TEntity> Get( ) {
            var set=  dbset.AsNoTracking();
            return set;
        }
        public TEntity GetById(int id) {
          
            var e= dbset.Find(id);
            
            return e;
        }
        public void Save(TEntity entity) {
          
            dbset.Add(entity);
            context.SaveChanges();
        }
        public void Update(TEntity entityToUpdate) {
            context.Entry(entityToUpdate).State = EntityState.Modified;
            context.SaveChanges();
        }
        public TEntity DeleteEntity(int id) {
            TEntity entity = dbset.Find(id);
            if (entity != null)
            {
                dbset.Remove(entity);
                context.SaveChanges();
            }
            return entity;
        }


    }
}
