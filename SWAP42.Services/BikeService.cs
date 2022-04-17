namespace SWAP42.Services
{
    using SWAP42.Core.Contracts.Helpers;
    using SWAP42.Core.Contracts.Repositories;
    using SWAP42.Core.Contracts.Services;
    using SWAP42.Core.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BikeService : IBikeService
    {
        private IBikeRepository _repository;
        private IConfigReader _configReader;

        public BikeService(IBikeRepository repository, IConfigReader configReader)
        {
            this._repository = repository;
            this._configReader = configReader;
        }

        public async Task<IEnumerable<Bike>> GetBikeTheftsByLocation(string location)
        {
            var taskResult = await this._repository.GetBikes(location, this._configReader.GetDistance(), this._configReader.GetStolenness());

            var filteredResult = taskResult.Bikes.Where(bike => bike.IsStolen == true);

            return filteredResult;
        }

        public async Task<BikeSearchCountResult> GetBikeTheftCountByLocation(string location)
        {
            var taskResult = await this._repository.GetBikeCount(location, this._configReader.GetDistance(), this._configReader.GetStolenness());
            taskResult.Location = location;

            return taskResult;
        }
    }
}