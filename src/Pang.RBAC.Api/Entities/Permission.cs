using System;
namespace Pang.RBAC.Api.Entities
{
    /// <summary>
    /// 权限表
    /// </summary>
    public class Permission: Entity
    {
        /// <summary>
        /// 权限类型/名称
        /// </summary>
        /// <value></value>
        public string Name{get; set;}
    }
}