using System;
using System.Collections;
using System.Threading.Tasks;
using Haarlemmertrekvaart.Configuration;
using NUnit.Framework;

namespace Haarlemmertrekvaart.UnitTests.Clients
{
    public class NsClientTests
    {
        [SetUp]
        public void SetUp()
        {
           
        }

        [Test]
        public async Task Test_My_Expectations()
        {
            var expectation = 0;
            Assert.That(expectation, Is.Not.Null);
        }

        //[Test]
        //[TestCaseSource(typeof(ArgumentExceptionTestCases))]
        //public void NsClient_Throws_ArgumentException_If_Args_Is_NullOrWhiteSpace(string username, string password)
        //{
        //    // Assert.That(() => new NsClient(username, password), Throws.TypeOf<ArgumentException>());
        //}

        //public class ArgumentExceptionTestCases : IEnumerable
        //{
        //    public IEnumerator GetEnumerator()
        //    {
        //        yield return new TestCaseData("username", " ");
        //        yield return new TestCaseData(" ", " ");
        //        yield return new TestCaseData("", string.Empty);
        //        yield return new TestCaseData("username", string.Empty);
        //        yield return new TestCaseData(string.Empty, string.Empty);
        //        yield return new TestCaseData(string.Empty, "password");
        //        yield return new TestCaseData(string.Empty, "");
        //    }
        //}
    }
}
