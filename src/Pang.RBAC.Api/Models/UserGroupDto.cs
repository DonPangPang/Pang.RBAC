using System;

namespace Pang.RBAC.Api.Models
{
    /// <summary>
    /// �û���
    /// </summary>
    public class UserGroupDto : BaseDto
    {
        /// <summary>
        /// �û�����
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ���û���Id
        /// </summary>
        public Guid ParentId { get; set; }
    }
}