using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCTest.Models;

namespace MVCTest.Models
{
    public class EFCustomerRepository : IGenericRepository<Customer> 
    {
        AppDbContext context;
        DbSet<Customer> dbset;
        public EFCustomerRepository(AppDbContext ctx)
        {
            context = ctx;

            dbset = ctx.Set<Customer>();
        }
        public IQueryable<Customer> Get()
        {
            
            return dbset.Include(x=>x.Founders) ;
        }
        public Customer GetById(int id)
        {
            return dbset.Include(x => x.Founders).FirstOrDefault(x => x.CustomerID == id);
        }
        public void Save(Customer entity)
        {

            dbset.Add(entity);
            context.SaveChanges();
        }
        public void Update(Customer entityToUpdate)
        {
            Customer r = context.Set<Customer>().Include(x => x.Founders).FirstOrDefault(x => x.CustomerID == entityToUpdate.CustomerID);
            if (r != null) {
                r.DateAdd = entityToUpdate.DateAdd;
                r.DateUpdate = entityToUpdate.DateUpdate;
                r.INN = entityToUpdate.INN;
                r.name = entityToUpdate.name;
                r.Founders = entityToUpdate.Founders;
            }
            context.SaveChanges();
        }
        public Customer DeleteEntity(int id)
        {
            Customer entity = dbset.Find(id);
            if (entity != null)
            {
                dbset.Remove(entity);
                context.SaveChanges();
            }
            return entity;
        }


    }
}
