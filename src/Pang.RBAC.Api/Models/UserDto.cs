namespace Pang.RBAC.Api.Models
{
    /// <summary>
    /// �û�
    /// </summary>
    public partial class UserDto : BaseDto
    {
        /// <summary>
        /// �û���
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Password { get; set; }
    }
}