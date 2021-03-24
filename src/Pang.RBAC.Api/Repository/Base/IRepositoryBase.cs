using Pang.RBAC.Api.DtoParameters.Base;
using Pang.RBAC.Api.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pang.RBAC.Api.Repository.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        void AddEntity(T eneity);
        Task AddEntityAsync(T entity);
        void AddEntities(IEnumerable<T> entities);
        Task AddEntitiesAsync(IEnumerable<T> entities);

        void Delete(T entity);
        Task DeleteAsync(T entity);
        void DeleteById(Guid id);
        Task DeleteByIdAsync(Guid id);
        void DeleteByIds(IEnumerable<Guid> ids);
        Task DeleteByIdsAsync(IEnumerable<Guid> ids);

        void UpdateEntity(T eneity);
        Task UpdateEntityAsync(T entity);
        void UpdateEntities(IEnumerable<T> entities);
        Task UpdateEntitiesAsync(IEnumerable<T> entities);

        Task<PagedList<T>> GetEntitiesAsync(DtoParametersBase parameter);
        Task<T> GetEntityByIdAsync(Guid id);
        Task<IEnumerable<T>> GetEntitiesAsync();
        Task<IEnumerable<T>> GetEntitiesCollectionAsync(IEnumerable<Guid> ids);

        Task<bool> EntityExistsAsync(Guid id);
        
        Task<IEnumerable<T>> GetChildren(Guid id);

        Task<bool> SaveAsync();
    }
}