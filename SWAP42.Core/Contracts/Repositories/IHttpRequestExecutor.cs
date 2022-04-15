namespace SWAP42.Core.Contracts.Repositories
{
    public interface IHttpRequestExecutor
    {
        Task<HttpResponseMessage> ExecuteAsync(HttpRequestMessage request, 
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead);
    }
}
