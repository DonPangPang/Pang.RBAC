using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pang.RBAC.Api.Controllers.Base;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Models;
using Pang.RBAC.Api.Repository;
using Pang.RBAC.Api.Repository.Base;

namespace Pang.RBAC.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    [Authorize("Identify")]
    public class UserGroupController : MyControllerBase<UserGroupRepository, UserGroup, UserGroupDto>
    {
        private readonly UserGroupRepository _userGroupRepository;
        private readonly IMapper _mapper;
        public UserGroupController(UserGroupRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _userGroupRepository = repository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetChildrens(Guid id)
        {
            var childrens = await _userGroupRepository.GetChildrens(id);

            var returnDtos = _mapper.Map<IEnumerable<UserGroup>>(childrens);

            return Ok(returnDtos);
        }
    }
}