namespace SWAP42.Repositories
{
    using SWAP42.Core.Contracts.Helpers;

    public class ConfigReader : IConfigReader
    {
        public string GetDistance()
        {
            return "20";
        }

        public string GetStolenness()
        {
            return "proximity";
        }
    }
}
