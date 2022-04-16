namespace SWAP42.Core.Models
{
    using Newtonsoft.Json;

    public class Bike
    {
        [JsonProperty("date_stolen")]
        public long? DateStolen { get; set; }

        [JsonProperty("frame_colors")]
        public IEnumerable<string>? FrameColors { get; set; }

        [JsonProperty("frame_model")]
        public string FrameModel { get; set; }

        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("manufacturer_name")]
        public string ManufacturerName { get; set; }

        [JsonProperty("serial")]
        public string Serial { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("stolen")]
        public bool? IsStolen { get; set; }

        [JsonProperty("stolen_coordinates")]
        public IEnumerable<double>? StolenCoordinates { get; set; }

        [JsonProperty("stolen_location")]
        public string StolenLocation { get; set; }

        [JsonProperty("thumb")]
        public string Thumb { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("year")]
        public int? Year { get; set; }
    }
}
