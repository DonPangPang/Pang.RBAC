using System;

namespace Pang.RBAC.Api.Models
{
    /// <summary>
    /// 操作
    /// </summary>
    public class FunctionOperationDto : BaseDto
    {
        /// <summary>
        /// 操作名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 操作编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 拦截Url前缀
        /// <para>
        /// 例如: /api/Create....那么这个请求在用户使用的时候就会被拦截, 无法访问
        /// </para>
        /// </summary>
        public string InterceptUrl { get; set; }

        /// <summary>
        /// 父操作ID
        /// </summary>
        public Guid ParentId { get; set; }
    }
}