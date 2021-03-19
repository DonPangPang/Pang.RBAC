using System;
namespace Pang.RBAC.Api.Entities
{
    /// <summary>
    /// 菜单表
    /// </summary>
    public class Menu: Entity
    {
        /// <summary>
        /// 菜单名
        /// </summary>
        /// <value></value>
        public string Name{get; set;}
        /// <summary>
        /// 菜单Url
        /// </summary>
        /// <value></value>
        public string Url{get; set;}
        /// <summary>
        /// 父菜单Id
        /// </summary>
        /// <value></value>
        public Guid ParentId{get; set;}

        public PermissionMenuAss PermissionMenuAss{get; set;}
    }
}