using System.Collections.Generic;

namespace Stone.Domain.Contracts
{
    public interface IRepositoryBase<TEntity, TKey>
            where TEntity : class
            where TKey : struct
    {
        void Insert(TEntity obj);
        void Delete(TEntity obj);
        void Update(TEntity obj);
        IList<TEntity> FindAll();
        TEntity FindById(TKey id);
    }
}
