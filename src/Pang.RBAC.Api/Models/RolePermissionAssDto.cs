using System;

namespace Pang.RBAC.Api.Models
{
    /// <summary>
    /// ��ɫ��Ȩ��֮��Ĺ���
    /// </summary>
    public class RolePermissionAssDto : BaseDto
    {
        /// <summary>
        /// ��ɫId
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// Ȩ��Id
        /// </summary>
        public Guid PermissionId { get; set; }
    }
}