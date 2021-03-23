using Microsoft.EntityFrameworkCore;
using Pang.RBAC.Api.Data;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pang.RBAC.Api.Repository
{
    public class UserRoleAssRepository : RepositoryBase<UserRoleAss>
    {
        public UserRoleAssRepository(PangDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UserRoleAss>> GetRolesByUserId(Guid userId)
        {
            var data = await _dbSet.Where(x => x.UserId == userId).ToListAsync();

            return data;
        }
    }
}