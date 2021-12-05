using System.Collections;
using System.Collections.Generic;

namespace Amir.Apparel.Demo.Api.Dotnet.Data.Models
{
    public interface IPage
    {
        int TotalElements { get; set; }
        int TotalPages { get; set; }
        bool Empty { get; set; }
        int Size { get; set; }
        int Number { get; set; }
        int NumberOfElements { get; set; }
    }
    public interface IPage<T> : IPage
    {
        IEnumerable<T> Content { get; set; }
    }
}
