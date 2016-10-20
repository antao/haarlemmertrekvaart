using System.Threading.Tasks;
using Haarlemmertrekvaart.Configuration;
using NUnit.Framework;

namespace Haarlemmertrekvaart.UnitTests
{
    public class NsClientTests
    {
        [Test]
        public void NsClient_Throws_ArgumentNullException_If_ConnectionConfiguration_Is_Null()
        {
            Assert.That(() => new NsClient(null), Throws.ArgumentNullException);
        }
    }
}
