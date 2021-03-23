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
    public class UserRepository : RepositoryBase<User>
    {
        private readonly UserUserGroupAssRepository _userUserGroupAssRepository;
        private readonly UserGroupRepository _userGroupRepository;
        private readonly UserRoleAssRepository _userRoleAssRepository;
        private readonly RoleRepository _roleRepository;

        public UserRepository(
            PangDbContext context,
            UserUserGroupAssRepository userUserGroupAssRepository,
            UserGroupRepository userGroupRepository,
            UserRoleAssRepository userRoleAssRepository,
            RoleRepository roleRepository) : base(context)
        {
            _userUserGroupAssRepository = userUserGroupAssRepository ?? throw new ArgumentNullException(nameof(userUserGroupAssRepository));
            _userGroupRepository = userGroupRepository ?? throw new ArgumentNullException(nameof(userGroupRepository));
            _userRoleAssRepository = userRoleAssRepository ?? throw new ArgumentNullException(nameof(userRoleAssRepository));
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
        }

        public async Task<User> GetUserByUserNameAsync(string username)
        {
            return await _dbSet.FirstAsync(x => x.Username == username);
        }

        public async Task<bool> UserExistAsync(string username)
        {
            return await _dbSet.AnyAsync(x => x.Username == username);
        }

        /// <summary>
        /// 获取用户的用户组, 虽然大部分时间都只有一个
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <returns>用户组的集合</returns>
        public async Task<IEnumerable<UserGroup>> GetUserGroup(Guid id)
        {
            var userGroup = await _dbSet.Where(x => x.Id == id)
                .Join(_userUserGroupAssRepository._dbSet, users => users.Id, ugAsses => ugAsses.UserId,
                    (users, ugAsses) => new { users, ugAsses })
                .Join(_userGroupRepository._dbSet, @t => @t.ugAsses.UserGroupId, userGroups => userGroups.Id,
                    (@t, userGroups) => new { userGroups })
                .Select(x => x.userGroups).ToListAsync();

            return userGroup;
        }

        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Role>> GetUserRoles(Guid id)
        {
            var roles = await _dbSet.Where(x => x.Id == id)
                .Join(_userRoleAssRepository._dbSet, user => user.Id, urAss => urAss.UserId,
                    (user, urAss) => new { user, urAss })
                .Join(_roleRepository._dbSet, @t => @t.urAss.Id, role => role.Id, (@t, role) => new { role })
                .Select(x => x.role).ToListAsync();

            return roles;
        }
    }
}