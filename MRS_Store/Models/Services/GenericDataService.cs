using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

namespace MRS_Store.Models.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DbObject
    {
        private readonly StoreDbContextFactory _contextFactory;
        public GenericDataService(StoreDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public T Create(T entity)
        {
            using (StoreDbContext dbContext = _contextFactory.CreateDbContext())
            {
                entity.CreatedDateTime = DateTime.Now;
                if( Globals.Session.Instance.User !=null )
                {
                    entity.CreatedBy = Globals.Session.Instance.User.Id.ToString();
                }
                EntityEntry<T> createdResult = dbContext.Set<T>().Add(entity);
                dbContext.SaveChanges();
                return createdResult.Entity;
            }
        }

        public bool Delete(Int64 id)
        {
            using (StoreDbContext dbContext = _contextFactory.CreateDbContext())
            {
                T entity =  dbContext.Set<T>().FirstOrDefault((e) => e.Id == id);
                dbContext.Set<T>().Remove(entity);
                 dbContext.SaveChanges();
                return true;
            }
        }

        public  T Get(Int64 id)
        {
            using (StoreDbContext dbContext = _contextFactory.CreateDbContext())
            {
                T entity =  dbContext.Set<T>().FirstOrDefault((e) => e.Id == id);
                return entity;
            }
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            using (StoreDbContext dbContext = _contextFactory.CreateDbContext())
            {
                T entity = dbContext.Set<T>().FirstOrDefault(expression);
                return entity;
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (StoreDbContext dbContext = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = dbContext.Set<T>().ToList();
                
                return entities;
            }
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            using (StoreDbContext dbContext = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = dbContext.Set<T>().Where(expression).ToList();

                return entities;
            }
        }

        public T Update(Int64 id, T entity)
        {
            using (StoreDbContext dbContext = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                dbContext.Set<T>().Update(entity);
                dbContext.SaveChanges();
                return entity;
            }
        }
    }
}
