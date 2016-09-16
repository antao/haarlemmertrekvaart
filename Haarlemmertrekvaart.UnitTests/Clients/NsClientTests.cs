using System;
using System.Collections;
using Haarlemmertrekvaart.Clients;
using NUnit.Framework;

namespace Haarlemmertrekvaart.UnitTests.Clients
{
    [TestFixture]
    [Parallelizable]
    public class NsClientTests
    {
        // private NsClient _target;

        [SetUp]
        public void SetUp()
        {
            // _target = new NsClient("joao.antao", "password");
        }

        [Test]
        [TestCaseSource(typeof(ArgumentExceptionTestCases))]
        public void NsClient_Throws_ArgumentException_If_Args_Is_NullOrWhiteSpace(string username, string password)
        {
            Assert.That(() => new NsClient(username, password), Throws.TypeOf<ArgumentException>());
        }

        public class ArgumentExceptionTestCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new TestCaseData("username", " ");
                yield return new TestCaseData(" ", " ");
                yield return new TestCaseData("", string.Empty);
                yield return new TestCaseData("username", string.Empty);
                yield return new TestCaseData(string.Empty, string.Empty);
                yield return new TestCaseData(string.Empty, "password");
                yield return new TestCaseData(string.Empty, "");
            }
        }
    }
}
