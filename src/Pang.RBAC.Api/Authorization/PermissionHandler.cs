using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Pang.RBAC.Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pang.RBAC.Api.Authorization
{
    /// <summary>
    /// 重写AuthorizationHandler
    /// </summary>
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly UserRepository _userRepository;
        private readonly RoleRepository _roleRepository;
        private readonly UserRoleAssRepository _userRoleAssRepository;
        private readonly FunctionOperationRepository _functionOperationRepository;
        private readonly PermissionRepository _permissionRepository;
        private readonly RolePermissionAssRepository _rolePermissionAssRepository;
        private readonly PermissionFunctionOperationAssRepository _permissionFunctionOperationAssRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly PermissionRequirement _tokenParameter;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="roleRepository"></param>
        /// <param name="userRoleAssRepository"></param>
        /// <param name="permissionRepository"></param>
        /// <param name="rolePermissionAssRepository"></param>
        /// <param name="permissionFunctionOperationAssRepository"></param>
        /// <param name="functionOperationRepository"></param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="config"></param>
        public PermissionHandler(UserRepository userRepository,
                                 RoleRepository roleRepository,
                                 UserRoleAssRepository userRoleAssRepository,
                                 PermissionRepository permissionRepository,
                                 RolePermissionAssRepository rolePermissionAssRepository,
                                 PermissionFunctionOperationAssRepository permissionFunctionOperationAssRepository,
                                 FunctionOperationRepository functionOperationRepository,
                                 IHttpContextAccessor httpContextAccessor,
                                 IConfiguration config)
        {
            if (config is null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            _userRoleAssRepository = userRoleAssRepository ?? throw new ArgumentNullException(nameof(userRoleAssRepository));
            _permissionRepository = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
            _rolePermissionAssRepository = rolePermissionAssRepository ?? throw new ArgumentNullException(nameof(rolePermissionAssRepository));
            _permissionFunctionOperationAssRepository = permissionFunctionOperationAssRepository ?? throw new ArgumentNullException(nameof(permissionFunctionOperationAssRepository));
            _functionOperationRepository = functionOperationRepository ?? throw new ArgumentNullException(nameof(functionOperationRepository));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));

            _tokenParameter = config.GetSection("TokenParameter").Get<PermissionRequirement>();
        }

        /// <summary>
        /// 重写HandleRequirementAsync
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requirement"></param>
        /// <returns></returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            // 校验 颁发和接收对象
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth &&
                                        c.Issuer == _tokenParameter.Issuer))
            {
                return Task.CompletedTask;
            }

            var dateOfBirth = Convert.ToDateTime(context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth &&
                                            c.Issuer == _tokenParameter.Issuer)
                ?.Value);

            // var test = TimeZone.CurrentTimeZone.ToLocalTime(Convert.ToDateTime(_tokenParameter.AccessExpiration));
            // 校验过期时间
            var accessExpiration = dateOfBirth.AddMinutes(_tokenParameter.AccessExpiration);
            var nowExpiration = DateTime.Now;
            if (accessExpiration < nowExpiration)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            // ReSharper disable once PossibleNullReferenceException
            var id = Guid.Parse(context.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value);

            var user = _userRepository.GetEntityByIdAsync(id).Result;

            if (user.IsSuper)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            var funcOperations = (from a in _userRepository._dbSet.Where(x=>x.Id == id)
                                  join b in _userRoleAssRepository._dbSet
                                  on a.Id equals b.UserId
                                  join c in _roleRepository._dbSet
                                  on b.RoleId equals c.Id
                                  join d in _rolePermissionAssRepository._dbSet
                                  on c.Id equals d.RoleId
                                  join e in _permissionRepository._dbSet
                                  on d.PermissionId equals e.Id
                                  join f in _permissionFunctionOperationAssRepository._dbSet
                                  on e.Id equals f.PermissionId
                                  join g in _functionOperationRepository._dbSet
                                  on f.FunctionOperationId equals g.Id
                                  select new { g }).Select(x=>x.g).ToList();

            var httpContext = _httpContextAccessor.HttpContext;
            var questUrl = httpContext?.Request.Path;

            if (funcOperations.Any(x => new Regex(x.InterceptUrl).Match(questUrl ?? "").Success))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}