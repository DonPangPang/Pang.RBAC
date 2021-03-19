using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace Pang.RBAC.Api.Entities
{
    /// <summary>
    /// 权限文件关联表
    /// </summary>
    public class PermissionFileResourceAss: Entity
    {
        /// <summary>
        /// 权限Id
        /// </summary>
        /// <value></value>
        public Guid PermissionId{get; set;}
        /// <summary>
        /// 文件Id
        /// </summary>
        /// <value></value>
        public Guid FileResourceId{get; set;}

        /// <summary>
        /// 权限
        /// </summary>
        /// <value></value>
        public Permission Permission{get; set;}
        /// <summary>
        /// 文件
        /// </summary>
        /// <value></value>
        public FileResource FileResource{get; set;}
    }
}