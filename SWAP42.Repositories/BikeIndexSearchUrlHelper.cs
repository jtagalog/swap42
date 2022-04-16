namespace SWAP42.Repositories
{
    using SWAP42.Core.Contracts.Helpers;

    public class BikeIndexSearchUrlHelper : IBikeSearchUrlHelper
    {
        public string GetBikeSearchUrl(string location, string distance, string stolenness)
        {
            return string.Format("https://bikeindex.org:443/api/v3/search/count?location={0}&distance={1}&stolenness={2}", location, distance, stolenness);
        }
    }
}
