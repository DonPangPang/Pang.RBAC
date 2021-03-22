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

            // modelBuilder.Entity<User>(x=>{
            //     x.HasMany(y => y.UserRoleAsses)
            //     .WithOne()
            //     .HasForeignKey(z=>z.UserId)
            //     .HasPrincipalKey(e=>e.Id)
            //     .OnDelete(DeleteBehavior.Cascade);
            // });

            // modelBuilder.Entity<Role>(x=>{
            //     x.HasMany(y => y.UserRoleAsses)
            //     .WithOne()
            //     .HasForeignKey(z=>z.RoleId)
            //     .HasPrincipalKey(e=>e.Id)
            //     .OnDelete(DeleteBehavior.Cascade);
            // });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.Parse("3fa85f64-5717-4562-f3fc-2c963f66afa6"),
                    Username = "admin",
                    Password = "admin",
                    IsSuper = true
                }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = Guid.Parse("4fa85f64-5717-4562-f3fc-2c963f66afa6"),
                    Name = "admin"
                }
            );

            modelBuilder.Entity<UserRoleAss>().HasData(
                new UserRoleAss
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.Parse("3fa85f64-5717-4562-f3fc-2c963f66afa6"),
                    RoleId = Guid.Parse("4fa85f64-5717-4562-f3fc-2c963f66afa6")
                });

            modelBuilder.Entity<RolePermissionAss>().HasData(
                new RolePermissionAss
                {
                    Id = Guid.NewGuid(),
                    RoleId = Guid.Parse("4fa85f64-5717-4562-f3fc-2c963f66afa6"),
                    PermissionId = Guid.Parse("5fa85f64-5717-4562-f3fc-2c963f66afa6")
                });

            modelBuilder.Entity<Permission>().HasData(
                new Permission
                {
                    Id = Guid.Parse("5fa85f64-5717-4562-f3fc-2c963f66afa6"),
                    Name = "admin"
                });

            modelBuilder.Entity<FunctionOperation>().HasData(
                new FunctionOperation
                {
                    Id = Guid.Parse("6fa85f64-5717-4562-f3fc-2c963f66afa6"),
                    Name = "admin",
                    Code = "/api",
                    InterceptUrl = "/api"
                });

            modelBuilder.Entity<PermissionFunctionOperationAss>().HasData(
                new PermissionFunctionOperationAss
                {
                    Id = Guid.NewGuid(),
                    PermissionId = Guid.Parse("5fa85f64-5717-4562-f3fc-2c963f66afa6"),
                    FunctionOperationId = Guid.Parse("6fa85f64-5717-4562-f3fc-2c963f66afa6")
                });

            // modelBuilder.Entity<UserRoleAss>().HasData(
            //     new UserRoleAss{
            //         Id = Guid.Parse("5fa85f64-5717-4562-f3fc-2c963f66afa6"),
            //         UserId = Guid.Parse("3fa85f64-5717-4562-f3fc-2c963f66afa6"),
            //         RoleId = Guid.Parse("4fa85f64-5717-4562-f3fc-2c963f66afa6")
            //     }
            // );

            base.OnModelCreating(modelBuilder);
        }
    }
}