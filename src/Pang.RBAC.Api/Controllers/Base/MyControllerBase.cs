using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pang.RBAC.Api.DtoParameters.Base;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pang.RBAC.Api.Controllers.Base
{
    /// <summary>
    /// 基础Api配置
    /// </summary>
    /// <typeparam name="TRepository">仓储类型</typeparam>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TModel">模型类型</typeparam>
    public class MyControllerBase<TRepository, TEntity, TModel> : ControllerBase
                where TRepository : RepositoryBase<TEntity> where TEntity : Entity
    {
        private readonly TRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// 实例化基础Api配置
        /// </summary>
        /// <param name="repository">配置仓储</param>
        /// <param name="mapper">映射器</param>
        public MyControllerBase(RepositoryBase<TEntity> repository, IMapper mapper)
        {
            _repository = (TRepository)(repository ?? throw new ArgumentNullException(nameof(repository)));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// 获取所有的实体
        /// </summary>
        /// <returns>所有的实体数据</returns>
        [HttpGet]
        public async Task<IActionResult> GetEntitiesAsync()
        {
            var data = await _repository.GetEntitiesAsync();

            var returnDto = _mapper.Map<IEnumerable<TModel>>(data);

            return Ok(returnDto);
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="parameters">参数</param>
        /// <returns>分页数据</returns>
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

        /// <summary>
        /// 通过Id获取数据
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>数据</returns>
        [HttpGet]
        public async Task<IActionResult> GetEntityByIdAsync(Guid id)
        {
            var data = await _repository.GetEntityByIdAsync(id);

            var returnDto = _mapper.Map<TModel>(data);

            return Ok(returnDto);
        }

        /// <summary>
        /// 通过数据集合获取数据
        /// </summary>
        /// <param name="ids">Id集合</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetEntitiesCollectionAsync([FromBody] IEnumerable<Guid> ids)
        {
            var entities = await _repository.GetEntitiesCollectionAsync(ids);

            if (ids.Count() != entities.Count())
            {
                return NotFound();
            }

            var returnDto = _mapper.Map<IEnumerable<TModel>>(entities);

            return Ok(returnDto);
        }

        /// <summary>
        /// 创建一条实体数据
        /// </summary>
        /// <param name="entity">实体数据(Id不必填写)</param>
        /// <returns>创建的数据</returns>
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

        /// <summary>
        /// 更新一条实体的数据
        /// </summary>
        /// <param name="id">要更新的数据的Id</param>
        /// <param name="entity">更新的数据</param>
        /// <returns>更新后的数据</returns>
        [HttpPut]
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

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="id">要删除的数据的Id</param>
        /// <returns>删除的数据</returns>
        [HttpDelete]
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