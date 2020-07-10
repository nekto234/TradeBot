namespace SeleniumCore.Models
{
    public class SeleniumSettings
    {
        public string UserDataDir { get; set; } = "./";

        public string ProfileDirectory { get; set; }

        public bool IsDisableExtensions { get; set; } = false;

        public bool IsHeadless { get; set; }
    }
}
