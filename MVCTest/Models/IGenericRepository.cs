using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTest.Models
{
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        IQueryable<TEntity> Get();
        TEntity GetById(int id);
        void Save(TEntity entity);
        void Update(TEntity entityToUpdate);
        TEntity DeleteEntity(int id);
    }
}
