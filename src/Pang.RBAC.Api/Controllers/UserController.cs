using System.Diagnostics.Contracts;
using System;
using System.Collections;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Repository;
using Pang.RBAC.Api.DtoParameters;
using Pang.RBAC.Api.Controllers.Base;

namespace Pang.RBAC.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class UserController : MyControllerBase<UserRepository, User>
    {
        private readonly UserRepository _userRepository;
        private readonly RoleRepository _roleRepository;
        private readonly UserRoleAssRepository _userRoleAssRepository;
        public UserController(UserRepository userRepository,
                              RoleRepository roleRepository,
                              UserRoleAssRepository userRoleAssRepository) : base(userRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            _userRoleAssRepository = userRoleAssRepository ?? throw new ArgumentNullException(nameof(userRoleAssRepository));
        }

        #region 丢弃

        // [HttpGet]
        // public async Task<IActionResult> GetUsersAsync()
        // {
        //     var data = await _userRepository.GetEntitiesAsync();

        //     return Ok(data);
        // }

        // [HttpGet]
        // public async Task<IActionResult> GetUsersByPaged([FromQuery]UserDtoParameters parameters)
        // {
        //     if (parameters is null)
        //     {
        //         throw new ArgumentNullException(nameof(parameters));
        //     }

        //     var data = await _userRepository.GetEntitiesAsync(parameters);

        //     // HACK: UserController 添加Links
        //     return Ok(data);
        // }

        // [HttpGet]
        // [Route("{UserId}")]
        // public async Task<IActionResult> GetUserByIdAsync(Guid UserId)
        // {
        //     var data = await _userRepository.GetEntityByIdAsync(UserId);
        //     return Ok(data);
        // }

        // [HttpPost]
        // public async Task<IActionResult> CreateUserAsync([FromBody] User user)
        // {
        //     if (user is null)
        //     {
        //         return NotFound();
        //     }

        //     _userRepository.AddEntity(user);
        //     await _userRepository.SaveAsync();

        //     return NoContent();
        // }

        // [HttpPut]
        // public async Task<IActionResult> UpdateUserAsync([FromBody]User user)
        // {
        //     if(user is null){
        //         throw new ArgumentNullException(nameof(user));
        //     }

        //     _userRepository.UpdateEntity(user);
        //     await _userRepository.SaveAsync();

        //     return NoContent();
        // }

        // [HttpDelete]
        // [Route("{userId}")]
        // public async Task<IActionResult> DeleteUserAsync(Guid userId)
        // {
        //     if (userId == Guid.Empty)
        //     {
        //         return BadRequest();
        //     }

        //     if (!await _userRepository.EntityExistsAsync(userId))
        //     {
        //         return BadRequest();
        //     }

        //     _userRepository.DeleteById(userId);
        //     await _userRepository.SaveAsync();
        //     return NoContent();
        // }

        #endregion

        // [HttpGet]
        // [Route("{id}")]
        // public async Task<IActionResult> GetRole(Guid id)
        // {
        //     return Ok();
        // }

    }
}