namespace SWAP42.Services
{
    using SWAP42.Core.Contracts.Helpers;
    using SWAP42.Core.Contracts.Repositories;
    using SWAP42.Core.Contracts.Services;
    using SWAP42.Core.Models;
    using System.Threading.Tasks;

    public class BikeService : IBikeService
    {
        private IBikeSearchUrlHelper _bikeSearchUriHelper;
        private IBikeRepository _repository;
        private IConfigReader _configReader;

        public BikeService(IBikeSearchUrlHelper bikeSearchUrlHelper, IBikeRepository repository, IConfigReader configReader)
        {
            this._bikeSearchUriHelper = bikeSearchUrlHelper;
            this._repository = repository;
            this._configReader = configReader;
        }

        public async Task<BikeSearchResult> GetTheftCountByLocation(string location)
        {
            var endpointUrl = this._bikeSearchUriHelper.GetBikeSearchUrl(location, this._configReader.GetDistance(), this._configReader.GetStolenness());

            var taskResult = await this._repository.GetBikes(endpointUrl);
            taskResult.Location = location;

            return taskResult;
        }
    }
}