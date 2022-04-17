namespace SWAP42.Core.Contracts.Helpers
{
    public interface IConfigReader
    {
        public string GetDistance();

        public string GetStolenness();

        public string GetOperatedCities();

        public string GetToExpandCities();
    }
}
