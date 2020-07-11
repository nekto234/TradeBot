using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamModule.Dto
{
    public class SteamItemBaseDto
    {
        [JsonProperty("success")]
        public bool IsSucccess { get; set; }

        [JsonProperty("buy_order_graph")]
        public List<List<string>> BuyOrder { get; set; }

        [JsonProperty("sell_order_graph")]
        public List<List<string>> SellOrder { get; set; }
    }
}
