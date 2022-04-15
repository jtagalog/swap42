namespace SWAP42.Repositories
{
    using SWAP42.Core.Contracts.Repositories;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class HttpRequestExecutor : IHttpRequestExecutor
    {
        private readonly HttpClient _httpClient;

        public HttpRequestExecutor()
        {
            this._httpClient = new HttpClient();
            this._httpClient.Timeout = Timeout.InfiniteTimeSpan;
        }

        public async Task<HttpResponseMessage> ExecuteAsync(HttpRequestMessage request, 
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
        {
            request.Headers.Add("Accept", "application/json;odata=nometadata");

            return await this._httpClient.SendAsync(request, completionOption);
        }
    }
}
