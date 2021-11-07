using System.Collections.Generic;

namespace amir_apparel_demo_api_dotnet_5.Data.Models
{
    public class Page<T>
    {
        public IEnumerable<T> Content { get; set; }
        public int TotalPages { get; set; }
        public bool Empty { get; set; }
        public int Size { get; set; }
        public int Number { get; set; }
        public int NumberOfElements { get; set; }
        public int TotalElements { get; set; }
    }
}
