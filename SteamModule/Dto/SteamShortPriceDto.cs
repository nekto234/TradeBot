using Newtonsoft.Json;

namespace SteamModule.Dto
{
    public class SteamShortPriceDto
    {
        [JsonProperty("success")]
        public bool IsSuccess { get; set; }

        [JsonProperty("lowest_price")]
        public string LowestPrice { get; set; }

        [JsonProperty("volume")]
        public string Volume { get; set; }

        [JsonProperty("median_price")]
        public string MedianPrice { get; set; }
    }
}
