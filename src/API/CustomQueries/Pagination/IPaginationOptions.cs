namespace Amir.Apparel.Demo.Api.Dotnet.API.CustomQueries
{
    public interface IPaginationOptions
    {
        public int Page { get; set; }

        public int Size { get; set; }

        public string[] Sort { get; set; }
    }
}
