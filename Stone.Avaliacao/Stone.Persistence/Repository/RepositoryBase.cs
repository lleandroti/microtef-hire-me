using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Stone.Domain.Contracts;
using Stone.Persistence.Context;

namespace Stone.Persistence.Repository
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        protected DataContext Con;

        public RepositoryBase()
        {
            Con = new DataContext();
        }

        public void Insert(TEntity obj)
        {
            Con.Entry(obj).State = EntityState.Added;
            Con.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            Con.Entry(obj).State = EntityState.Modified;
            Con.SaveChanges();
        }

        public void Delete(TEntity obj)
        {
            Con.Entry(obj).State = EntityState.Deleted;
            Con.SaveChanges();
        }

        public IList<TEntity> FindAll()
        {
            return Con.Set<TEntity>().ToList();
        }

        public TEntity FindById(TKey id)
        {
            return Con.Set<TEntity>().Find(id);
        }        
    }
}
