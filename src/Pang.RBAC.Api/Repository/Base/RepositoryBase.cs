using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pang.RBAC.Api.Data;
using Pang.RBAC.Api.DtoParameters.Base;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Helpers;

namespace Pang.RBAC.Api.Repository.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        private readonly PangDbContext _context;
        public DbSet<T> _dbSet{get;}
        public RepositoryBase(PangDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual void AddEntity(T eneity)
        {
            if (eneity == null)
            {
                throw new ArgumentNullException(nameof(eneity));
            }

            eneity.Id = Guid.NewGuid();

            _dbSet.Add(eneity);
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbSet.Remove(entity);
        }

        public void DeleteById(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var entity = GetEntityByIdAsync(id).Result;
            _dbSet.Remove(entity);
        }

        public virtual async Task<bool> EntityExistsAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await _dbSet.AnyAsync(x => x.Id == id);
        }

        public virtual async Task<IEnumerable<T>> GetChildrens(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var queryExpression = _dbSet as IQueryable<T>;
            queryExpression = queryExpression.Where(x => x.GetType().GetProperty("ParentId").GetValue(x, null).Equals(id));

            var data = await queryExpression.ToListAsync();

            return data;
        }

        public virtual async Task<IEnumerable<T>> GetEntitiesCollectionAsync(IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                throw new ArgumentNullException(nameof(ids));
            }

            return await _dbSet.Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetEntitiesAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<PagedList<T>> GetEntitiesAsync(DtoParametersBase parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var queryExpression = _dbSet as IQueryable<T>;

            return await PagedList<T>.CreateAsync(queryExpression, parameters.PageNumber, parameters.PageSize);
        }

        public virtual async Task<T> GetEntityByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public virtual void UpdateEntity(T eneity)
        {
            _dbSet.Update(eneity);
        }
    }
}