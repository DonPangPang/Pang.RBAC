using System.Security.Claims;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Repository;
using System.Collections.Generic;

namespace Pang.RBAC.Api.Authorization
{
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        private UserRepository _userRepository { get; set; }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (!InitRepositorys(requirement))
            {
                context.Fail();
            }

            // var claims = context.User.Claims;
            
            // var claim = claims.FirstOrDefault(x=>x.Type.Equals(ClaimTypes.Name));

            // var val = claim.Value;

            // var id = Guid.Parse(claim.Value);

            // var user = _userRepository.GetEntityByIdAsync(id).Result;

            // if (user.IsSuper)
            // {
            //     context.Succeed(requirement);
            // }
            // else
            // {
            //     context.Fail();
            // }

            context.Succeed(requirement);
            return Task.CompletedTask;
        }

        private bool InitRepositorys(PermissionRequirement requirement)
        {
            try
            {
                var serviceProvider = requirement.ServiceProvider;

                _userRepository = serviceProvider.GetService(typeof(UserRepository)) as UserRepository;

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}