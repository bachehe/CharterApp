using CharterApp.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharterApp.Tests.Geometries
{
    public class GeometrySTRESSTests
    {
        [Test]
        [TestCase(0, 0, 0, 0)]
        [TestCase(100, 1, 42.5, 101.179)]
        [TestCase(100, 10, 42.5, 99.657)]
        [TestCase(100, 20, 42.5, 95.092)]
        [TestCase(100, 30, 42.5, 87.637)]
        [TestCase(100, 40, 42.5, 77.519)]
        [TestCase(100, 50, 42.5, 65.046)]
        [TestCase(100, 60, 42.5, 50.597)]
        [TestCase(100, 70, 42.5, 34.611)]
        [TestCase(100, 80, 42.5, 17.572)]
        [TestCase(100, 90, 42.5, 0)]
        public void Zfunction_ForGivenValues_ShouldReturnExpectedResult(double linear, int tetha, double angle, double expected)
        {
            var sut = new GeometrySTRESS();
            sut.Parameters[0].Value = linear;
            sut.Parameters[1].Value = angle;

            var res = Math.Round(sut.ZFunction(tetha), 3);

            Assert.That(res, Is.EqualTo(expected));
        }
    }
}
