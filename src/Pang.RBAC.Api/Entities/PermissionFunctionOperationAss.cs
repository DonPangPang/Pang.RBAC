using System;
namespace Pang.RBAC.Api.Entities
{
    public class PermissionFunctionOperationAss: Entity
    {
        /// <summary>
        /// 权限Id
        /// </summary>
        /// <value></value>
        public Guid PermissionId{get; set;}
        /// <summary>
        /// 功能操作Id
        /// </summary>
        /// <value></value>
        public Guid FunctionOperationId{get; set;}

        /// <summary>
        /// 权限
        /// </summary>
        /// <value></value>
        public Permission Permission{get; set;}
        /// <summary>
        /// 功能操作
        /// </summary>
        /// <value></value>
        public FunctionOperation FunctionOperation{get; set;}
    }
}