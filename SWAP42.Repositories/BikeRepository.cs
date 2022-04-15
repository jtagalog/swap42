namespace SWAP42.Repositories
{
    using Newtonsoft.Json;
    using SWAP42.Core.Contracts.Repositories;
    using SWAP42.Core.Models;
    using System.Threading.Tasks;

    public class BikeRepository : IBikeRepository
    {
        private IHttpRequestExecutor _httpExecutor;

        public BikeRepository(IHttpRequestExecutor httpExecutor)
        {
            this._httpExecutor = httpExecutor;
        }

        public async Task<BikeSearchResult> GetBikes(string endpointUrl)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, endpointUrl))
            {
                var response = await this._httpExecutor.ExecuteAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var result = await response.Content.ReadAsStringAsync();

                var bikeSearchCountResult = JsonConvert.DeserializeObject<BikeSearchResult>(result);
                
                return bikeSearchCountResult;
            }
        }
    }
}