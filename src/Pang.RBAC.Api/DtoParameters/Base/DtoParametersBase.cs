namespace Pang.RBAC.Api.DtoParameters.Base
{
    public class DtoParametersBase
    {
        private const int MaxPageSize = 30;
        public string Q { get; set; }
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 5;
        public string OrderBy { get; set; } = "Id";
        public string Fields { get; set; }

        public int PageSize
        {
            get => _pageSize = 5;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}