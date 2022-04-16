namespace SWAP42.Core.Models
{
    using Newtonsoft.Json;

    public class BikeSearchResult
    {
        [JsonProperty("bikes")]
        public IEnumerable<Bike> Bikes { get; set; }
    }
}
