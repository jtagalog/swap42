namespace SWAP42.Services
{
    using Newtonsoft.Json;
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
            var taskResult = await this._repository.GetBikes<BikeSearchResult>(location, this._configReader.GetDistance(), this._configReader.GetStolenness());

            var filteredResult = taskResult.Bikes.Where(bike => bike.IsStolen == true);

            return filteredResult;
        }

        public async Task<BikeSearchCountResult> GetBikeTheftCountByLocation(string location)
        {
            var taskResult = await this._repository.GetBikeCount<BikeSearchCountResult>(location, this._configReader.GetDistance(), this._configReader.GetStolenness());
            taskResult.Location = location;

            return taskResult;
        }

        public async Task<IEnumerable<BikeSearchCountResult>> GetBikeTheftsInOperatedCities()
        {
            var cities = JsonConvert.DeserializeObject<string[]>(this._configReader.GetOperatedCities());

            return await this.ExecuteRequests(cities);
        }

        public async Task<IEnumerable<BikeSearchCountResult>> GetBikeTheftsInToExpandCities()
        {
            var cities = JsonConvert.DeserializeObject<string[]>(this._configReader.GetToExpandCities());

            return await this.ExecuteRequests(cities);
        }

        private async Task<IEnumerable<BikeSearchCountResult>> ExecuteRequests(string[] cities)
        {
            var tasks = cities.Select(city => this.GetBikeTheftCountByLocation(city));

            return await Task.WhenAll(tasks);
        }
    }
}