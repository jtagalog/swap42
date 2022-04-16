namespace SWAP42.Core.Contracts.Repositories
{
    using SWAP42.Core.Models;

    public interface IBikeRepository
    {
        Task<BikeSearchResult> GetBikes(string location, string distance, string stolenness);

        Task<BikeSearchCountResult> GetBikeCount(string location, string distance, string stolenness);
    }
}
