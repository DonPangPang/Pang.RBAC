using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Pang.RBAC.Api.Controllers.Base;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Models;
using Pang.RBAC.Api.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pang.RBAC.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    [Authorize("Identify")]
    [EnableCors("Any")]
    public class MenuController : MyControllerBase<MenuRepository, Menu, MenuDto>
    {
        private readonly MenuRepository _menuRepository;
        private readonly IMapper _mapper;

        public MenuController(MenuRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _menuRepository = repository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetChildrens(Guid id)
        {
            var childrens = await _menuRepository.GetChildren(id);

            var returnDtos = _mapper.Map<IEnumerable<MenuDto>>(childrens);

            return Ok(returnDtos);
        }
    }
}