using System;
namespace Pang.RBAC.Api.Entities
{
    /// <summary>
    /// 页面元素表
    /// </summary>
    public class PageElement: Entity
    {
        /// <summary>
        /// 页面元素编码
        /// </summary>
        /// <value></value>
        public string Code{get; set;}

        public PermissionPageElementAss PermissionPageElementAss{get; set;}
    }
}