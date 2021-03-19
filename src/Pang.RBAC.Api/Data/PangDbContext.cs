using System;
using Microsoft.EntityFrameworkCore;
using Pang.RBAC.Api.Entities;
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


            modelBuilder.Entity<User>().HasData(
                new User{
                    Id = Guid.Parse("3fa85f64-5717-4562-f3fc-2c963f66afa6"),
                    Username = "admin",
                    Password = "admin",
                    IsSuper = true
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}