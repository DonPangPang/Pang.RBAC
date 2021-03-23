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
    public class UserGroupRepository : RepositoryBase<UserGroup>
    {
        public UserGroupRepository(PangDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<UserGroup>> GetChildren(Guid id)
        {
            var data = await _dbSet.Where(x => x.ParentId == id).ToListAsync();

            return data;
        }
    }
}