using Pang.RBAC.Api.Data;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Repository.Base;

namespace Pang.RBAC.Api.Repository
{
    public class PermissionRepository : RepositoryBase<Permission>
    {
        public PermissionRepository(PangDbContext context) : base(context)
        {
        }
    }
}