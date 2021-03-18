using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pang.RBAC.Api.Controllers.Base;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Repository;
using Pang.RBAC.Api.Repository.Base;

namespace Pang.RBAC.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class UserGroupController : MyControllerBase<UserGroupRepository, UserGroup>
    {
        private readonly UserGroupRepository _userGroupRepository;
        public UserGroupController(UserGroupRepository repository) : base(repository)
        {
            _userGroupRepository = repository;
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetChildrens(Guid id)
        {
            var childrens = await _userGroupRepository.GetChildrens(id);

            return Ok(childrens);
        }
    }
}