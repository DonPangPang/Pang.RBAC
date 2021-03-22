using System;

namespace Pang.RBAC.Api.Models
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class MenuDto : BaseDto
    {
        /// <summary>
        /// 菜单名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 菜单Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 父菜单Id
        /// </summary>
        public Guid ParentId { get; set; }
    }
}