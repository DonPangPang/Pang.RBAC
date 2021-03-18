using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pang.RBAC.Api.DtoParameters.Base;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Repository.Base;

namespace Pang.RBAC.Api.Controllers.Base
{
    public class MyControllerBase<TRepository, TEntity> : ControllerBase 
                where TRepository : RepositoryBase<TEntity> where TEntity : Entity
    {
        private TRepository _repository;
        public MyControllerBase(RepositoryBase<TEntity> repository)
        {
            _repository = (TRepository)(repository ?? throw new ArgumentNullException(nameof(repository)));
        }

        [HttpGet]
        public async Task<IActionResult> GetEntitisAsync()
        {
            var data = await _repository.GetEntitiesAsync();

            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetEntitiesByPagedAsync([FromQuery]DtoParametersBase parameters)
        {
            if (parameters is null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var data = await _repository.GetEntitiesAsync(parameters);

            // HACK: UserController 添加Links
            return Ok(data);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEntityByIdAsync(Guid id)
        {
            var data = await _repository.GetEntityByIdAsync(id);
            return Ok(data);
        }

        [HttpGet]
        [Route("{ids}")]
        public async Task<IActionResult> GetEntitiesCollectionAsync(IEnumerable<Guid> ids)
        {
            var entities = await _repository.GetEntitiesCollectionAsync(ids);

            if(ids.Count() != entities.Count())
            {
                return NotFound();
            }

            return Ok(entities);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntityAsync([FromBody] TEntity entity)
        {
            if (entity is null)
            {
                return NotFound();
            }

            _repository.AddEntity(entity);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEntityAsync([FromBody] TEntity entity)
        {
            if(entity is null){
                throw new ArgumentNullException(nameof(entity));
            }

            _repository.UpdateEntity(entity);
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
                return BadRequest();
            }

            _repository.DeleteById(id);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}