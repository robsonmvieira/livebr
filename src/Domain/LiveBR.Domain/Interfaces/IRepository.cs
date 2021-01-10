using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LiveBR.Domain.Entities;

namespace LiveBR.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity: Entity
    {
        public Task Add(TEntity entity);

        public Task<IEnumerable<TEntity>> ListAll();

        public Task<TEntity> FindById(Guid id);

        public Task Update(TEntity entity);

        public Task Remove(TEntity entity);
        public Task<IEnumerable<TEntity>> GetListByExpression(Expression<Func<TEntity, bool>> expression);
        public Task<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expression);
    }
}