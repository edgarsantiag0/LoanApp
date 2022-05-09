using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        private readonly IRepositoryManager _repositoryManager;

        protected readonly DbSet<T> _entities;

        protected DbContext Context
        {
            get
            {
                return _repositoryManager.Context;
            }
        }

        public RepositoryBase(IRepositoryManager repositoryManager)
        {
            _entities = repositoryManager.Context.Set<T>();
            _repositoryManager = repositoryManager;
        }

        public IQueryable<T> FindAll(bool trackChanges) => trackChanges ?
            _entities
            .Where(o => o.IsDeleted == false) :
            _entities
            .AsNoTracking()
            .Where(o => o.IsDeleted == false);

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            trackChanges ?
            _entities
            .Where(o => o.IsDeleted == false)
            .Where(expression) :
            _entities
            .AsNoTracking()
            .Where(o => o.IsDeleted == false)
            .Where(expression);

        public void Create(T entity)
        {
            entity.Created = DateTime.Now;
            entity.Modified = DateTime.Now;
            entity.IsDeleted = false;
            _entities.Add(entity);
        }

        public void Update(T entity)
        {
            entity.Modified = DateTime.Now;
            _entities.Update(entity);
        }

        public void Delete(T entity) => _entities.Remove(entity);

        public void Save() => _repositoryManager.Save();

        public async Task SaveAsync() => await _repositoryManager.SaveAsync();
    }
}
