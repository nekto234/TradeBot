using Newtonsoft.Json;
using SeleniumCore;
using Shared.Exceptions;
using Shared.Interfaces;
using SteamModule.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace SteamModule
{
    public class Steam<T> : ISteam<T> where T : ISteamItem, new()
    {
        private readonly SeleniumWebDriver seleniumWebDriver;

        public Steam(SeleniumWebDriver seleniumWebDriver)
        {
            this.seleniumWebDriver = seleniumWebDriver;
        }

        public async Task<T> GetPriceById(string id, T model)
        {
            string steamItemUrl = SteamConst.InfoSteamItemUrl(id);
           
            var webClient = new WebClient();
            string requestResult = webClient.DownloadString(steamItemUrl);

            var itemDto = JsonConvert.DeserializeObject<SteamItemBaseDto>(requestResult);

            if (itemDto.IsSucccess)
                FillPriceInModel(itemDto, model);
            else
                throw new ItemNotFoundException($"Item with this Id: {id} was not found at Steam market");

            return model;
        }

        /// <summary>
        /// Return only Price and CountBySellPrice
        /// </summary>
        /// <param name="name"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<T> GetShortPriceInfoByName(string name, T model)
        {
            string encodeName = HttpUtility.UrlEncode(name, Encoding.UTF8);
            encodeName = encodeName.Replace("+", "%20"); // Replace space to code

            string steamItemUrl = SteamConst.PriceSteamItemUrl(encodeName);

            var webClient = new WebClient();
            string requestResult = webClient.DownloadString(steamItemUrl);

            var itemDto = JsonConvert.DeserializeObject<SteamShortPriceDto>(requestResult);

            if(itemDto.IsSuccess)
            {
                model.Price = Convert.ToDouble(itemDto.LowestPrice);
                model.SaleCount = Convert.ToInt32(itemDto.Volume);
            }

            return model;
        }

        public async Task<T> GetByName(string name, T model)
        {
            string encodeName = HttpUtility.UrlEncode(name, Encoding.UTF8);
            encodeName = encodeName.Replace("+", "%20"); // Replace space to code
            string steamItemUrl = SteamConst.GeneralSteamItemUrl(encodeName);

            seleniumWebDriver.GoToUrl(steamItemUrl);

            string pageSource = seleniumWebDriver.ChromeDriver.PageSource;

            // Find id
            string pattern = @"(?<=Market_LoadOrderSpread\()(.*?)(?=\))";
            model.GeneralId = Regex.Match(pageSource, pattern).Value.Trim();

            await GetPriceById(model.GeneralId, model);

            return model;
        }

        public async Task PostOrderOnMarket()
        {

        }

        private T FillPriceInModel(SteamItemBaseDto itemDto, T model)
        {
            itemDto.BuyOrder = itemDto.BuyOrder.OrderByDescending(x => x[0]).ToList();

            var firstElementInSequence = itemDto.BuyOrder[0];
            var seccondElementInSequence = itemDto.BuyOrder[1];
      

            double dif = Convert.ToDouble(firstElementInSequence[0]) - Convert.ToDouble(seccondElementInSequence[0]);
            double percent = dif * 100 / Convert.ToDouble(firstElementInSequence[0]);

            if(percent < 5)
            {
                model.OrderPrice = Convert.ToDouble(firstElementInSequence[0]);
                model.CountByOrderPrice = Convert.ToInt32(firstElementInSequence[1]);
            }
            else
            {
                model.OrderPrice = itemDto.BuyOrder.Take(10).Average(x => Convert.ToDouble(x[0]));
                model.CountByOrderPrice = itemDto.BuyOrder.Take(10).Sum(x => Convert.ToInt32(x[1]));
            }

            itemDto.SellOrder = itemDto.SellOrder.OrderByDescending(x => x[0]).ToList();
            firstElementInSequence = itemDto.SellOrder[0];
            seccondElementInSequence = itemDto.SellOrder[1];

            dif = Convert.ToDouble(firstElementInSequence[0]) - Convert.ToDouble(seccondElementInSequence[0]);
            percent = dif * 100 / Convert.ToDouble(firstElementInSequence[0]);

            if (percent < 5)
            {
                model.Price = Convert.ToDouble(firstElementInSequence[0]);
                model.CountBySellPrice = Convert.ToInt32(firstElementInSequence[1]);
            }
            else
            {
                model.Price = itemDto.SellOrder.Take(10).Average(x => Convert.ToDouble(x[0]));
                model.CountBySellPrice = itemDto.SellOrder.Take(10).Sum(x => Convert.ToInt32(x[1]));
            }

            return model;
        }

        public Task GetSteamInventory(string steamId)
        {
            string steamInventoryUrl = SteamConst.SteamInventoryUrl(steamId);

            var webClient = new WebClient();
            string requestResult = webClient.DownloadString(steamInventoryUrl);

            var fileResult = File.ReadAllText(@"H:\Works\Project\Core\TradeBot\json.txt");
            var itemDto = JsonConvert.DeserializeObject<SteamInventoryDto>(fileResult);


            throw new NotImplementedException();
        }
    }
}
