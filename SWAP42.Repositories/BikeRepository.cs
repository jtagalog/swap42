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
        private IConfigReader _configReader;

        public BikeRepository(IHttpRequestExecutor httpExecutor, IBikeSearchUrlHelper bikeSearchUrlHelper, IConfigReader configReader)
        {
            this._httpExecutor = httpExecutor;
            this._bikeSearchUriHelper = bikeSearchUrlHelper;
            this._configReader = configReader;
        }

        public async Task<BikeSearchResult> GetBikesCount(string location)
        {
            var endpointUrl = this._bikeSearchUriHelper.GetBikeSearchUrl(location, this._configReader.GetDistance(), this._configReader.GetStolenness());
            var result = await this._httpExecutor.ExecuteGetAsync(endpointUrl);

            var bikeSearchCountResult = JsonConvert.DeserializeObject<BikeSearchResult>(result);

            return bikeSearchCountResult;
        }
    }
}