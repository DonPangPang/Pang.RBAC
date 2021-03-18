using Pang.RBAC.Api.Data;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Repository.Base;

namespace Pang.RBAC.Api.Repository
{
    public class UserRepository : RepositoryBase<User>
    {
        public UserRepository(PangDbContext context) : base(context)
        {
        }
    }
}