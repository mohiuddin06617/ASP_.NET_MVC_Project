using PWEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWRepository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity:Entity
    {
        DataAccessContext dataContext = new DataAccessContext();
        public List<TEntity> GetAll()
        {
            return dataContext.Set<TEntity>().ToList();
        }

        public TEntity Get(int id)
        {
            return dataContext.Set<TEntity>().Find(id);
        }

        public int Insert(TEntity entity)
        {
            dataContext.Set<TEntity>().Add(entity);
            return dataContext.SaveChanges();
        }

        public int Update(TEntity entity)
        {
            dataContext.Entry<TEntity>(entity).State = EntityState.Modified;
            return dataContext.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            dataContext.Set<TEntity>().Remove(entity);
            return dataContext.SaveChanges();
        }
    }
}
