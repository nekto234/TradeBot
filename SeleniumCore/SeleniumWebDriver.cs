using OpenQA.Selenium.Chrome;
using SeleniumCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCore
{
    public class SeleniumWebDriver
    {
        public ChromeOptions ChromeWebDriverOptions { get; private set; }

        private ChromeDriver chromeDriver;

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

            var chromeDriverService = ChromeDriverService.CreateDefaultService();

            chromeDriver = new ChromeDriver(chromeDriverService, ChromeWebDriverOptions);
        }
    }
}
