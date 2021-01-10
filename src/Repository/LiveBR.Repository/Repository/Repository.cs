using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LiveBR.CrossCutting.Interfaces;
using LiveBR.Domain.Entities;
using LiveBR.Domain.Interfaces;
using LiveBR.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace LiveBR.Repository.Repository
{
    public class Repository<TEntity>: IRepository<TEntity> where TEntity: Entity 
    {
        private readonly LiveBrContext _liveBrContext;
        private readonly DbSet<TEntity> Query;
        private IUnitOfWork _unitOfWork => _liveBrContext;

        public Repository(LiveBrContext liveBrContext)
        {
            _liveBrContext = liveBrContext;
            Query = _liveBrContext.Set<TEntity>();
        }
       
        public async Task Add(TEntity entity)
        {
            await Query.AddAsync(entity);
            await _unitOfWork.Commit();
        }

        public async Task<IEnumerable<TEntity>> ListAll()
        {
            return await Query.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> FindById(Guid id)
        {
            return await Query.FindAsync(id);
        }

        public async Task Update(TEntity entity)
        {
            Query.Update(entity);
            await _unitOfWork.Commit();
        }

        public async Task Remove(TEntity entity)
        {
            Query.Remove(entity);
            await _unitOfWork.Commit();
        }

        public async Task<IEnumerable<TEntity>> GetListByExpression(Expression<Func<TEntity, bool>> expression)
        {
            return await Task.FromResult(Query.Where(expression).AsEnumerable());
        }

        public async Task<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expression)
        {
            return await Query.Where(expression).FirstOrDefaultAsync();
        }
    }
}