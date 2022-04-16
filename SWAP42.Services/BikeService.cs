namespace SWAP42.Services
{
    using SWAP42.Core.Contracts.Repositories;
    using SWAP42.Core.Contracts.Services;
    using SWAP42.Core.Models;
    using System.Threading.Tasks;

    public class BikeService : IBikeService
    {
        private IBikeRepository _repository;

        public BikeService(IBikeRepository repository)
        {
            this._repository = repository;
        }

        public async Task<BikeSearchResult> GetTheftCountByLocation(string location)
        {
            var taskResult = await this._repository.GetBikesCount(location);
            taskResult.Location = location;

            return taskResult;
        }
    }
}