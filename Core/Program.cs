using Core.Models;
using SeleniumCore;
using SeleniumCore.Models;
using Shared.Interfaces;
using SteamModule;
using System;

namespace Core
{
    class Program
    {
        static void Main(string[] args)
        {
            SeleniumWebDriver seleniumWebDriver = new SeleniumWebDriver(new SeleniumSettings
            {
                IsDisableExtensions = false,
                IsHeadless = false,
                ProfileDirectory = "./ChromeDriver/Profile 2",
                UserDataDir = @"./ChromeDriver/"
            });

            ISteam<SteamItem> steam = new Steam<SteamItem>(seleniumWebDriver);
            //SteamItem steamItem = new SteamItem();
            //steam.GetByName("'The Doctor' Romanov | Sabre", steamItem);
            steam.GetSteamInventory("76561198875308001");
        }
    }
}
