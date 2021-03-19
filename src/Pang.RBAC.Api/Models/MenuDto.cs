using System;

namespace Pang.RBAC.Api.Models
{
    public class MenuDto : BaseDto
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
    }
}