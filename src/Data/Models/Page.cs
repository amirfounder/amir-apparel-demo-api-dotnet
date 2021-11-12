using amir_apparel_demo_api_dotnet_5.API.CustomRequestQueries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace amir_apparel_demo_api_dotnet_5.Data.Models
{
    public class Page<T>
    {
        public Page()
        { }
        public Page(IPaginationOptions paginationOptions)
        {
            _number = paginationOptions.Page;
            _size = paginationOptions.Size;
            _numberOfElements = paginationOptions.Size;
        }

        private IEnumerable<T> _content;
        private int _totalPages;
        private bool _empty;
        private int _size;
        private int _number;
        private int _numberOfElements;
        private int _totalElements;

        public IEnumerable<T> Content
        {
            get => _content;
            set
            {
                _content = value;
                _empty = !value.Any();
            }
        }
        public int TotalElements
        {
            get => _totalElements;
            set
            {
                _totalElements = value;
                _totalPages = (int)Math.Ceiling(_totalElements / (double)_size);
            }
        }
        public int TotalPages { get => _totalPages; }
        public bool Empty { get => _empty; }
        public int Size { get => _size; }
        public int Number { get => _number; }
        public int NumberOfElements { get => _numberOfElements; }
    }
}
