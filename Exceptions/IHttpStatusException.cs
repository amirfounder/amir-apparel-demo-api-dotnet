namespace amir_apparel_demo_api_dotnet_5.Exceptions
{
    public interface IHttpStatusException
    {
        HttpStatusExceptionErrorObject ErrorObject { get; set; }
    }
}
