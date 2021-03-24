using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Pang.RBAC.Api.Controllers.Base;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Models;
using Pang.RBAC.Api.Repository;
using System;
using System.Threading.Tasks;

namespace Pang.RBAC.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    [Authorize("Identify")]
    [EnableCors("Any")]
    public class UserController : MyControllerBase<UserRepository, User, UserDto>
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository, IMapper mapper) : base(userRepository, mapper)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserRoles(Guid id)
        {
            var data = await _userRepository.GetUserRoles(id);

            return Ok(data);
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

        #endregion 丢弃

        // [HttpGet]
        // [Route("{id}")]
        // public async Task<IActionResult> GetRoles(Guid id)
        // {
        //     if(id == Guid.Empty)
        //     {
        //         throw new ArgumentNullException(nameof(id));
        //     }

        //     var user = await _userRepository.GetEntitiesAsync();
        //     var ros = user.Select(x=>x.UserRoleAsses.Select(y=>y.Role));

        //     var userRoleAsses = await _userRoleAssRepository.GetRoles(id);
        //     var roleIds = userRoleAsses.Select(x=>x.RoleId).ToList();

        //     var roles = _roleRepository.GetEntitiesCollectionAsync(roleIds);

        //     return Ok(roles);
        // }
    }
}