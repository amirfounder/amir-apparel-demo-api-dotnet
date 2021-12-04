using Amir.Apparel.Demo.Api.Dotnet.Data.Models;

namespace Amir.Apparel.Demo.Api.Dotnet.API.CustomQueries
{
    public class ProductFilter : Filterable<Product>, IFilterable<Product>
    {
        public string Material { get; set; }
        public string Type { get; set; }
        public string Demographic { get; set; }
        public string Color { get; set; }
    }
}
