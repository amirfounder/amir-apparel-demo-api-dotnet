using System.Collections.Generic;

namespace Amir.Apparel.Demo.Api.Dotnet.Data.Models
{
    public interface IPage<T>
    {
        IEnumerable<T> Content { get; set; }
        int TotalElements { get; set; }
        int TotalPages { get; set; }
        bool Empty { get; set; }
        int Size { get; set; }
        int Number { get; set; }
        int NumberOfElements { get; set; }
    }
}
