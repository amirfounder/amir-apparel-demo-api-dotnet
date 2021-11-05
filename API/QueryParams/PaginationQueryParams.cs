namespace amir_apparel_demo_api_dotnet_5.API.QueryParams
{
    public class PaginationQueryParams
    {
        private const int maxSize = 50;

        public int Page { get; set; } = 1;

        private int _size;

        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = (value > maxSize) ? maxSize : value;
            }
        }
    }
}
