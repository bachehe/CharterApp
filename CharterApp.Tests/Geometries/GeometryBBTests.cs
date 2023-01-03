using CharterApp.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharterApp.Tests.Geometries
{
    public class GeometryBBTests
    {
        [Test]
        [TestCase(0,1,0)]
        [TestCase(100, 1, 2.614)]
        [TestCase(100, 10, 26.010)]
        [TestCase(100, 20, 51.23)]
        [TestCase(100, 30, 74.893)]
        [TestCase(100, 40, 96.281)]
        [TestCase(100, 50, 114.743)]
        [TestCase(100, 60, 129.719)]
        [TestCase(100, 70, 140.753)]
        [TestCase(100, 80, 147.511)]
        [TestCase(100, 90, 149.787)]
        public void Zfunction_ForGivenValues_ShouldReturnExpectedResult(double linear, int angle, double expected)
        {
            var sut = new GeometryBB();
            sut.Parameters[0].Value = linear;

            var res = Math.Round(sut.ZFunction(angle), 3);

            Assert.That(res, Is.EqualTo(expected));
        }
    }
}
 