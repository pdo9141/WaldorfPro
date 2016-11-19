using Waldorf.Common.Configurations;

namespace Waldorf.Tests
{
    public class CacheServerConfiguration : XmlDeserializeConfigSectionHandler
    {
        public string Address { get; set; }

        public int TimeToLiveInMinutes { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
