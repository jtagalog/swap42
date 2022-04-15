namespace SWAP42.Core.Contracts.Services
{
    using SWAP42.Core.Models;

    public interface IBikeService
    {
        Task<BikeSearchResult> GetTheftCountByLocation(string location);
    }
}
