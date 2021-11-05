namespace amir_apparel_demo_api_dotnet_5.API.Controllers
{
    public class ProductParameters
    {
        public const int maxPageSize = 50;
        public int Page { get; set; } = 1;
        private int _size = 10;
        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
