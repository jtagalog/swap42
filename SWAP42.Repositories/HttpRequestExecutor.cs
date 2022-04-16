namespace SWAP42.Repositories
{
    using SWAP42.Core.Contracts.Repositories;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class HttpRequestExecutor : IHttpRequestExecutor
    {
        private readonly HttpClient _httpClient;

        public HttpRequestExecutor(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<string> ExecuteGetAsync(string endpointUrl, 
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, endpointUrl))
            {
                request.Headers.Add("Accept", "application/json;odata=nometadata");

                var response = await this._httpClient.SendAsync(request, completionOption);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
