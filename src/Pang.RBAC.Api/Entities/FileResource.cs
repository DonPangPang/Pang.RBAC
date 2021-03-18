using System;
namespace Pang.RBAC.Api.Entities
{
    /// <summary>
    /// 文件表
    /// </summary>
    public class FileResource: Entity
    {
        /// <summary>
        /// 文件名
        /// </summary>
        /// <value></value>
        public string Name{get; set;}
        /// <summary>
        /// 文件路径
        /// </summary>
        /// <value></value>
        public string Url{get; set;} = null!;
    }
}