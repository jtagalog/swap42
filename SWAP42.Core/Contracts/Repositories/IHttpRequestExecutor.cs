namespace SWAP42.Core.Contracts.Repositories
{
    public interface IHttpRequestExecutor
    {
        Task<string> ExecuteGetAsync(string endpointUrl, 
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead);
    }
}
