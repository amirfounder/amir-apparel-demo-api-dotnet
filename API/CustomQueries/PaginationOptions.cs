namespace amir_apparel_demo_api_dotnet_5.API.QueryParams
{
    public class PaginationOptions
    {
        private const int maxSize = 50;

        public int Page { get; set; } = 0;

        private int _size = 25;

        public int Size
        {
            get => _size;
            set
            {
                if (Size > maxSize)
                {
                    _size = maxSize;
                }
                else
                {
                    _size = value;
                }
            }
        }

        private string _sort;

        public string Sort
        {
            get => _sort;
            set
            {
                // custom logic here
                _sort = "int,asc";
            }
        }
    }
}
