namespace SWAP42.Repositories
{
    using Newtonsoft.Json;
    using SWAP42.Core.Contracts.Helpers;
    using SWAP42.Core.Contracts.Repositories;
    using SWAP42.Core.Models;
    using System.Threading.Tasks;

    public class BikeRepository : IBikeRepository
    {
        private IHttpRequestExecutor _httpExecutor;
        private IBikeSearchUrlHelper _bikeSearchUriHelper;
       
        public BikeRepository(IHttpRequestExecutor httpExecutor, IBikeSearchUrlHelper bikeSearchUrlHelper)
        {
            this._httpExecutor = httpExecutor;
            this._bikeSearchUriHelper = bikeSearchUrlHelper;
        }

        public async Task<BikeSearchResult> GetBikes(string location, string distance, string stolenness)
        {
            var endpointUrl = this._bikeSearchUriHelper.GetBikeSearchUrl(location, distance, stolenness);
            var result = await this._httpExecutor.ExecuteGetAsync(endpointUrl);

            var bikeSearchResult = JsonConvert.DeserializeObject<BikeSearchResult>(result);

            return bikeSearchResult;
        }

        public async Task<BikeSearchCountResult> GetBikeCount(string location, string distance, string stolenness)
        {
            var endpointUrl = this._bikeSearchUriHelper.GetBikeSearchCountUrl(location, distance, stolenness);
            var result = await this._httpExecutor.ExecuteGetAsync(endpointUrl);

            var bikeSearchCountResult = JsonConvert.DeserializeObject<BikeSearchCountResult>(result);

            return bikeSearchCountResult;
        }
    }
}