namespace SWAP42.Core.Models
{
    using Newtonsoft.Json;

    public class BikeSearchResult
    {
        [JsonProperty("proximity")]
        public int Proximity { get; set; }

        public string Location { get; set; }
    }
}
