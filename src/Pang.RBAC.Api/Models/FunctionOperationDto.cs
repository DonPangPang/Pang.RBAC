using System;

namespace Pang.RBAC.Api.Models
{
    public class FunctionOperationDto : BaseDto
    {
        /// <summary>
        /// 操作名
        /// </summary>
        /// <value></value>
        public string Name{get; set;}
        /// <summary>
        /// 操作编码
        /// </summary>
        /// <value></value>
        public string Code{get; set;}
        /// <summary>
        /// 拦截Url前缀
        /// </summary>
        /// <value></value>
        public string InterceptUrl{get; set;}
        /// <summary>
        /// 父操作ID
        /// </summary>
        /// <value></value>
        public Guid ParentId{get; set;}
    }
}