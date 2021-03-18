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
    public class MenuRepository : RepositoryBase<Menu>
    {
        private readonly PangDbContext _context;
        private new DbSet<Menu> _dbSet;
        public MenuRepository(PangDbContext context) : base(context)
        {
            _context = context;
            _dbSet = base._dbSet as DbSet<Menu>;
        }

        public override async Task<IEnumerable<Menu>> GetChildrens(Guid id)
        {
            var data = await _dbSet.Where(x => x.ParentId == id).ToListAsync();

            return data;
        }
    }
}