namespace Pang.RBAC.Api.Models
{
    /// <summary>
    /// 权限
    /// </summary>
    public class PermissionDto : BaseDto
    {
        /// <summary>
        /// 权限类型/名称
        /// </summary>
        public string Name { get; set; }
    }
}