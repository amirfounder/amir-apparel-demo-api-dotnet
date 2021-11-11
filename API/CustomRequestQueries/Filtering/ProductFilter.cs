﻿using amir_apparel_demo_api_dotnet_5.Data.Models;

namespace amir_apparel_demo_api_dotnet_5.API.CustomRequestQueries
{
    public class ProductFilter : Filterable<Product>, IFilterable<Product>
    {
        public string Material { get; set; }
        public string Type { get; set; }
        public string Demographic { get; set; }
        public string Color { get; set; }
    }
}
