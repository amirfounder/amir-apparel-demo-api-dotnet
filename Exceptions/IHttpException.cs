namespace amir_apparel_demo_api_dotnet_5.Exceptions
{
    public interface IHttpResponseException
    {
        public int Status { get; }
        public object ObjectData { get; set; }
    }
}
