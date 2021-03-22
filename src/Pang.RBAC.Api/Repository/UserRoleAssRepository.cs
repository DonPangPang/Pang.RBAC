using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pang.RBAC.Api.Data;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Repository.Base;

namespace Pang.RBAC.Api.Repository
{
    public class UserRoleAssRepository : RepositoryBase<UserRoleAss>
    {
        private readonly PangDbContext _context;
        private new readonly DbSet<UserRoleAss> _dbSet;
        public UserRoleAssRepository(PangDbContext context) : base(context)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
            _dbSet = base._dbSet as DbSet<UserRoleAss>;
        }

        public async Task<IEnumerable<UserRoleAss>> GetRolesByUserId(Guid userId)
        {
            var data = await _dbSet.Where(x=>x.UserId == userId).ToListAsync();

            return data;
        }
    }
}