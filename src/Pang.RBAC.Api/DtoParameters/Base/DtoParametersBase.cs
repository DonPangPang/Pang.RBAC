namespace Pang.RBAC.Api.DtoParameters.Base
{
    public class DtoParametersBase
    {
        private const int MaxPageSize = 30;
        public string Q { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 5;
        public string OrderBy { get; set; } = "Id";
        public string Fields { get; set; }

        /// <summary>
        /// 每页数据条数
        /// </summary>
        public int PageSize
        {
            get => _pageSize = 5;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}