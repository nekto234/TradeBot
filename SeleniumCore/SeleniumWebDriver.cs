using OpenQA.Selenium.Chrome;
using SeleniumCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCore
{
    public class SeleniumWebDriver
    {
        public ChromeOptions ChromeWebDriverOptions { get; private set; }

        public ChromeDriver ChromeDriver { get; private set; }

        public SeleniumWebDriver(SeleniumSettings seleniumSettings)
        {
            ChromeWebDriverOptions = new ChromeOptions();

            ChromeWebDriverOptions.AddArguments(new List<string>()
            {
                $"user-data-dir={seleniumSettings.UserDataDir}",
                $"profile-directory={seleniumSettings.ProfileDirectory}",
            });

            if (seleniumSettings.IsDisableExtensions)
                ChromeWebDriverOptions.AddArgument("disable-extensions");

            if (seleniumSettings.IsHeadless)
                ChromeWebDriverOptions.AddArgument("headless");

            var chromeDriverService = ChromeDriverService.CreateDefaultService(seleniumSettings.UserDataDir);

            ChromeDriver = new ChromeDriver(chromeDriverService, ChromeWebDriverOptions);
        }

        public void GoToUrl(string url)
        {
           ChromeDriver.Navigate().GoToUrl(url);
        }
    }
}
