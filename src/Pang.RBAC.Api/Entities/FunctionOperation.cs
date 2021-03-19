using System;
namespace Pang.RBAC.Api.Entities
{
    /// <summary>
    /// 功能操作表
    /// </summary>
    public class FunctionOperation: Entity
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

        public PermissionFunctionOperationAss PermissionFunctionOperationAss{get; set;}
    }
}