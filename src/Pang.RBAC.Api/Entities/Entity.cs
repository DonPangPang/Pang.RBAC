using System;

namespace Pang.RBAC.Api.Entities
{
    /// <summary>
    /// 实体基类, 默认配置Id字段
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Id字段
        /// </summary>
        public Guid Id { get; set; }
    }
}