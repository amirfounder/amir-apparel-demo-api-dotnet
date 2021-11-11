namespace amir_apparel_demo_api_dotnet_5.HttpStatusExceptions
{
    public interface IHttpStatusException
    {
        HttpStatusExceptionErrorValue Value { get; set; }
    }
}
