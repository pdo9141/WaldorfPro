using System.Configuration;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Waldorf.Common.Security;

namespace Waldorf.Tests
{
    [TestClass]
    public class MiscTests
    {
        [TestMethod]
        public void Misc_Config_Section_Test()
        {
            var cacheServerConfiguration = (CacheServerConfiguration)ConfigurationManager.GetSection("CacheServerConfiguration");
        }

        [TestMethod]
        public void Misc_EncryptionHelper_Test()
        {
            string plain = "1111222233334444";
            string encrypted = EncryptionHelper.Encrypt<RijndaelManaged>(plain, "password", "salt");
            string decrypted = EncryptionHelper.Decrypt<RijndaelManaged>(encrypted, "password", "salt");
        }
    }
}
