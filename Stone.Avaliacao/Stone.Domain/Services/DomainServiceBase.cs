using System;
using System.Collections.Generic;
using Stone.Domain.Contracts;

namespace Stone.Domain.Services
{
    public class DomainServiceBase<TEntity, TKey> : IDomainServiceBase<TEntity, TKey>
            where TEntity : class
            where TKey : struct
    {
        private readonly IRepositoryBase<TEntity, TKey> _repositorio;

        public DomainServiceBase(IRepositoryBase<TEntity, TKey> repositorio)
        {
            _repositorio = repositorio;
        }

        public virtual void Cadastrar(TEntity obj)
        {
            try
            {
                _repositorio.Insert(obj);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Atualizar(TEntity obj)
        {
            try
            {
                _repositorio.Update(obj);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Excluir(TEntity obj)
        {
            try
            {
                _repositorio.Delete(obj);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public TEntity ObterPorId(TKey id)
        {
            try
            {
                return _repositorio.FindById(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<TEntity> ObterTodos()
        {
            try
            {
                return _repositorio.FindAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
