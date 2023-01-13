using CharterApp.Models;
using CharterApp.Tests.Attribute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharterApp.Tests.Parameters
{
    [LinearFactor]
    public class LinearFactorTests
    {
        [Test]
        [TestCase(0, true)]
        [TestCase(-1, false)]
        [TestCase(50, true)]
        [TestCase(900, true)]
        [TestCase(1000, true)]
        [TestCase(10000, false)]
        [TestCase(1000000, false)]
        public void Validate_ForValue_ReturnsExpectedBool(double value, bool expected)
        {
            var sut = new LinearFactor();
            sut.Value = value;

            var res = sut.Validate();

            Assert.That(res, Is.EqualTo(expected));
        }
    }
}
