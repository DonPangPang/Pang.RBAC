using Microsoft.EntityFrameworkCore;
using Pang.RBAC.Api.Extensions;

namespace Pang.RBAC.Api.Data
{
    public class PangDbContext : DbContext
    {
        public PangDbContext(DbContextOptions<PangDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddEntityTypes();
            base.OnModelCreating(modelBuilder);
        }
    }
}