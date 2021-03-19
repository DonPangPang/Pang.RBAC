using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pang.RBAC.Api.DtoParameters.Base;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Repository.Base;

namespace Pang.RBAC.Api.Controllers.Base
{
    public class MyControllerBase<TRepository, TEntity, TModel> : ControllerBase
                where TRepository : RepositoryBase<TEntity> where TEntity : Entity
    {
        private readonly TRepository _repository;
        private readonly IMapper _mapper;

        public MyControllerBase(RepositoryBase<TEntity> repository, IMapper mapper)
        {
            _repository = (TRepository)(repository ?? throw new ArgumentNullException(nameof(repository)));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetEntitisAsync()
        {
            var data = await _repository.GetEntitiesAsync();

            var returnDto = _mapper.Map<IEnumerable<TModel>>(data);

            return Ok(returnDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetEntitiesByPagedAsync([FromQuery] DtoParametersBase parameters)
        {
            if (parameters is null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var data = await _repository.GetEntitiesAsync(parameters);
            var returnDto = _mapper.Map<IEnumerable<TModel>>(data);

            // HACK: UserController 添加Links
            return Ok(returnDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEntityByIdAsync(Guid id)
        {
            var data = await _repository.GetEntityByIdAsync(id);

            var returnDto = _mapper.Map<TModel>(data);

            return Ok(returnDto);
        }

        [HttpGet]
        [Route("{ids}")]
        public async Task<IActionResult> GetEntitiesCollectionAsync(IEnumerable<Guid> ids)
        {
            var entities = await _repository.GetEntitiesCollectionAsync(ids);

            if (ids.Count() != entities.Count())
            {
                return NotFound();
            }

            var returnDto = _mapper.Map<IEnumerable<TModel>>(entities);

            return Ok(returnDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntityAsync([FromBody] TModel entity)
        {
            if (entity is null)
            {
                return BadRequest();
            }

            var data = _mapper.Map<TEntity>(entity);

            _repository.AddEntity(data);
            await _repository.SaveAsync();

            var returnDto = _mapper.Map<TModel>(data);

            return Ok(returnDto);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEntityAsync(Guid id, [FromBody] TModel entity)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (!await _repository.EntityExistsAsync(id))
            {
                return NotFound();
            }

            var oldEntity = await _repository.GetEntityByIdAsync(id);

            if (oldEntity is null)
            {
                var addEntity = _mapper.Map<TEntity>(entity);
                addEntity.Id = id;

                _repository.AddEntity(addEntity);

                await _repository.SaveAsync();

                var dtoToReturn = _mapper.Map<TModel>(addEntity);

                return Ok(dtoToReturn);
            }

            _mapper.Map(entity, oldEntity);

            _repository.UpdateEntity(oldEntity);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEntityAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            if (!await _repository.EntityExistsAsync(id))
            {
                return NotFound();
            }

            _repository.DeleteById(id);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}