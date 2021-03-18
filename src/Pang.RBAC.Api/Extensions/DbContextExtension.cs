using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Pang.RBAC.Api.Entities;

namespace Pang.RBAC.Api.Extensions
{
    public static class DbContextExtension
    {
        public static ModelBuilder AddEntityTypes(this ModelBuilder modelBuilder)
        {
            var types = typeof(Entity).Assembly.GetTypes().AsEnumerable();
            var entityTypes = types.Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(Entity)));

            foreach (var type in entityTypes)
            {
                if (modelBuilder.Model.FindEntityType(type) is null)
                {
                    modelBuilder.Model.AddEntityType(type);
                }
            }

            return modelBuilder;
        }
    }
}