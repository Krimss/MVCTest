using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCTest.Models;

namespace MVCTest.Models
{
    public class EFFounderRepository : IGenericRepository<Founder>
    {
        AppDbContext context;
        DbSet<Founder> dbset;
        public EFFounderRepository(AppDbContext ctx)
        {
            context = ctx;

            dbset = ctx.Set<Founder>();
        }
        public IQueryable<Founder> Get()
        {
            return dbset.Include(x => x.Customers);
        }
        public Founder GetById(int id)
        {
            return dbset.Include(x => x.Customers).FirstOrDefault(x => x.FounderID == id);
        }
        public void Save(Founder entity)
        {

            dbset.Add(entity);
            context.SaveChanges();
        }
        public void Update(Founder entityToUpdate)
        {
            Founder r = context.Set<Founder>().Include(x => x.Customers).FirstOrDefault(x => x.FounderID == entityToUpdate.FounderID);
            if (r != null)
            {
                r.DateAdd = entityToUpdate.DateAdd;
                r.DateUpdate = entityToUpdate.DateUpdate;
                r.INN = entityToUpdate.INN;
                r.FIO = entityToUpdate.FIO;
                r.Customers = entityToUpdate.Customers;
            }
            context.SaveChanges();
        }
        public Founder DeleteEntity(int id)
        {
            Founder entity = dbset.Find(id);
            if (entity != null)
            {
                dbset.Remove(entity);
                context.SaveChanges();
            }
            return entity;
        }


    }
}
