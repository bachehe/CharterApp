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
    [AngleFactor]
    public class AngleFactorTests
    {
        [Test]
        [TestCase(0, true)]
        [TestCase(-1, false)]
        [TestCase(50, true)]
        [TestCase(90, true)]
        [TestCase(100, false)]
        public void Validate_ForValue_ReturnsExpectedBool(double value, bool expected)
        {
            var sut = new AngleFactor();
            sut.Value = value;

            var res = sut.Validate();

            Assert.That(res, Is.EqualTo(expected));
        }
    }
}
