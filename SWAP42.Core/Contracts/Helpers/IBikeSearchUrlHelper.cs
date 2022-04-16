namespace SWAP42.Core.Contracts.Helpers
{
    public interface IBikeSearchUrlHelper
    {
        string GetBikeSearchUrl(string location, string distance, string stolenness);

        string GetBikeSearchCountUrl(string location, string distance, string stolenness);
    }
}
