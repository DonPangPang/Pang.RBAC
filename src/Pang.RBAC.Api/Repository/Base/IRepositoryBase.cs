using Pang.RBAC.Api.DtoParameters.Base;
using Pang.RBAC.Api.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pang.RBAC.Api.Repository.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        Task AddEntity(T eneity);
        Task AddEntities(IEnumerable<T> entities);

        Task Delete(T entity);
        Task DeleteById(Guid id);
        Task DeleteByIds(IEnumerable<Guid> ids);

        Task UpdateEntity(T eneity);
        Task UpdateEntities(IEnumerable<T> entities);

        Task<PagedList<T>> GetEntitiesAsync(DtoParametersBase parameter);
        Task<T> GetEntityByIdAsync(Guid id);
        Task<IEnumerable<T>> GetEntitiesAsync();
        Task<IEnumerable<T>> GetEntitiesCollectionAsync(IEnumerable<Guid> ids);

        Task<bool> EntityExistsAsync(Guid id);
        
        Task<IEnumerable<T>> GetChildren(Guid id);

        Task<bool> SaveAsync();
    }
}