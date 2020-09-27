using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamModule.Dto
{
    public class Asset
    {

        [JsonProperty("appid")]
        public int Appid { get; set; }

        [JsonProperty("contextid")]
        public string Contextid { get; set; }

        [JsonProperty("assetid")]
        public string Assetid { get; set; }

        [JsonProperty("classid")]
        public string Classid { get; set; }

        [JsonProperty("instanceid")]
        public string Instanceid { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

    }

    public class Description
    {
        [JsonProperty("appid")]
        public int Appid { get; set; }

        [JsonProperty("classid")]
        public string Classid { get; set; }

        [JsonProperty("instanceid")]
        public string Instanceid { get; set; }

        [JsonProperty("currency")]
        public int Currency { get; set; }

        [JsonProperty("background_color")]
        public string BackgroundColor { get; set; }

        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }

        [JsonProperty("tradable")]
        public int Tradable { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_color")]
        public string NameColor { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("market_name")]
        public string MarketName { get; set; }

        [JsonProperty("market_hash_name")]
        public string MarketHashName { get; set; }

        [JsonProperty("commodity")]
        public int Commodity { get; set; }

        [JsonProperty("market_tradable_restriction")]
        public int MarketTradableRestriction { get; set; }

        [JsonProperty("marketable")]
        public int Marketable { get; set; }

        [JsonProperty("market_buy_country_restriction")]
        public string MarketBuyCountryRestriction { get; set; }

        [JsonProperty("icon_url_large")]
        public string IconUrlLarge { get; set; }

    }

    public class SteamInventoryDto
    {
        [JsonProperty("assets")]
        public List<Asset> Assets { get; set; }

        [JsonProperty("descriptions")]
        public List<Description> Descriptions { get; set; }

        [JsonProperty("total_inventory_count")]
        public int TotalInventoryCount { get; set; }

        [JsonProperty("success")]
        public int Success { get; set; }

    }
}
