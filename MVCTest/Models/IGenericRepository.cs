using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTest.Models
{
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        public IQueryable<TEntity> Get();
        public TEntity GetById(int id);
        public void Save(TEntity entity);
        public void Update(TEntity entityToUpdate);
        public TEntity DeleteEntity(int id);
    }
}
