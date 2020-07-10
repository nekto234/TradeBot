using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCore.Models
{
    public class WebDriverStatus
    {
        public int Id { get; set; }

        public ChromeDriver WebDriver { get; set; }

        public SeleniumSettings Settings { get; set; }

        public bool IsActive { get; set; }
    }
}
