using System.Collections.Generic;

namespace Stone.Domain.Contracts
{
    public interface IDomainServiceBase<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        void Cadastrar(TEntity obj);
        void Atualizar(TEntity obj);
        void Excluir(TEntity obj);

        IList<TEntity> ObterTodos();
        TEntity ObterPorId(TKey id);
    }
}