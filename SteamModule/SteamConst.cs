using System;
using System.Collections.Generic;
using System.Text;

namespace SteamModule
{
    public static class SteamConst
    {
        public static string GeneralSteamItemUrl(string encodeName)
        {
            return $"https://steamcommunity.com/market/listings/730/{encodeName}";
        }

        public static string InfoSteamItemUrl(string itemNameId, int currency = 1)
        {
            return $"https://steamcommunity.com/market/itemordershistogram?country=UA&language=russian&currency={currency}&item_nameid={itemNameId}&two_factor=0";
        }
    }
}
