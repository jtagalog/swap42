namespace SWAP42.Core.Contracts.Services
{
    using SWAP42.Core.Models;

    public interface IBikeService
    {
        Task<IEnumerable<Bike>> GetBikeTheftsByLocation(string location);

        Task<BikeSearchCountResult> GetBikeTheftCountByLocation(string location);
    }
}
