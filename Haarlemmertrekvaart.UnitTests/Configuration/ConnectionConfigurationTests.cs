using System;
using System.Collections;
using Haarlemmertrekvaart.Configuration;
using NUnit.Framework;

namespace Haarlemmertrekvaart.UnitTests.Configuration
{
    public class ConnectionConfigurationTests
    {
        private ConnectionConfiguration _target;

        [SetUp]
        public void SetUp()
        {
            _target = new ConnectionConfiguration("x", "y");
        }

        [Test]
        public void ConnectionConfiguration_HttpHeaders_Contains_BasicAuthentication()
        {
            Assert.That(_target.HttpHeaders.GetHeader("Authorization"), Is.Not.Null);
        }

        [Test]
        public void ConnectionConfiguration_HttpHeaders_Are_Not_Null()
        {
            Assert.That(_target.HttpHeaders, Is.Not.Null);
        }

        [Test, TestCaseSource(typeof(ArgumentNullExceptionTestCases))]
        public void ConnectionConfiguration_Throws_ArgumentNullException_If_Args_Is_NullOrWhiteSpace(string username, string key)
        {
            Assert.That(() => new ConnectionConfiguration(username, key), Throws.TypeOf<ArgumentNullException>());
        }

        public class ArgumentNullExceptionTestCases : IEnumerable
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
