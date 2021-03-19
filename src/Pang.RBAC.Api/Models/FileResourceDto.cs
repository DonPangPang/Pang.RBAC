namespace Pang.RBAC.Api.Models
{
    public class FileResourceDto : BaseDto
    {
        /// <summary>
        /// 文件名
        /// </summary>
        /// <value></value>
        public string Name{get; set;}
        /// <summary>
        /// 文件路径
        /// </summary>
        /// <value></value>
        public string Url{get; set;} = null!;
    }
}