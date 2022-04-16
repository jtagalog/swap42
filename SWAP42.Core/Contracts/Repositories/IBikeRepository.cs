namespace SWAP42.Core.Contracts.Repositories
{
    using SWAP42.Core.Models;

    public interface IBikeRepository
    {
        Task<BikeSearchResult> GetBikesCount(string location);
    }
}
