namespace Pang.RBAC.Api.Models
{
    /// <summary>
    /// 用户
    /// </summary>
    public partial class UserDto : BaseDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}