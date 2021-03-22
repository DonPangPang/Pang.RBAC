namespace Pang.RBAC.Api.Models
{
    /// <summary>
    /// 文件资源
    /// </summary>
    public class FileResourceDto : BaseDto
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string Url { get; set; } = null!;
    }
}