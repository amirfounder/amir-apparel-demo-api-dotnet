using Amir.Apparel.Demo.Api.Dotnet.API.CustomQueries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Amir.Apparel.Demo.Api.Dotnet.Data.Models
{
    public class Page<T>
    {
        public Page()
        { }
        public Page(IPaginationOptions paginationOptions)
        {
            Number = paginationOptions.Page;
            Size = paginationOptions.Size;
            NumberOfElements = paginationOptions.Size;
        }

        private int _totalElemenets;
        private IEnumerable<T> _content;

        public IEnumerable<T> Content
        {
            get => _content;
            set
            {
                _content = value;
                Empty = !value.Any();
            }
        }
        public int TotalElements
        {
            get => _totalElemenets;
            set
            {
                _totalElemenets = value;
                TotalPages = (int)Math.Ceiling(value / (double)Size);
            }
        }
        public int TotalPages { get; set; }
        public bool Empty { get; set; }
        public int Size { get; set; }
        public int Number { get; set; }
        public int NumberOfElements { get; set; }
    }
}
