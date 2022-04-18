namespace SWAP42.Core.Contracts.Repositories
{
    public interface IBikeRepository
    {
        Task<TResult> GetBikes<TResult>(string location, string distance, string stolenness) where TResult : class;

        Task<TResult> GetBikeCount<TResult>(string location, string distance, string stolenness) where TResult : class;
    }
}
