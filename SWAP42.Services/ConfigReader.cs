namespace SWAP42.Services
{
    using SWAP42.Core.Contracts.Helpers;

    public class ConfigReader : IConfigReader
    {
        public string GetDistance()
        {
            return "20";
        }

        public string GetOperatedCities()
        {
            return "[\"Amsterdam, The Netherlands\", \"Berlin, Germany\", \"Copenhagen, Denmark\", \"Brussels, Belgium\"]";
        }

        public string GetStolenness()
        {
            return "proximity";
        }

        public string GetToExpandCities()
        {
            return "[\"Milan, Italy\", \"London, UK\", \"Paris, France\"]";
        }
    }
}
