using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pang.RBAC.Api.DtoParameters.Base;
using Pang.RBAC.Api.Helpers;

namespace Pang.RBAC.Api.Repository.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        void AddEntity(T eneity);
        void Delete(T entity);
        void DeleteById(Guid id);
        void UpdateEntity(T eneity);
        Task<PagedList<T>> GetEntitiesAsync(DtoParametersBase parameter);
        Task<T> GetEntityByIdAsync(Guid id);
        Task<IEnumerable<T>> GetEntitiesAsync();
        Task<IEnumerable<T>> GetEntitiesCollectionAsync(IEnumerable<Guid> ids); 
        Task<bool> EntityExistsAsync(Guid id);

        Task<IEnumerable<T>> GetChildrens(Guid id);

        Task<bool> SaveAsync();
    }
}