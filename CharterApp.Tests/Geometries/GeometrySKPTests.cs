using CharterApp.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharterApp.Tests.Geometries
{
    public class GeometrySKPTests
    {
        [Test]
        [TestCase(0, 0, 0, 0)]
        [TestCase(100, 1, 1, 2.614)]
        [TestCase(100, 10, 1, 4.962)]
        [TestCase(100, 20, 1, 5.087)]
        [TestCase(100, 30, 1, 5.124)]
        [TestCase(100, 40, 1, 5.137)]
        [TestCase(100, 50, 1, 5.137)]
        [TestCase(100, 60, 1, 5.126)]
        [TestCase(100, 70, 1, 5.093)]
        [TestCase(100, 80, 1, 4.985)]
        [TestCase(100, 90, 1, 2.614)]
        [TestCase(100, 1, 2, 0)]
        [TestCase(100, 10, 2, 9.394)]
        [TestCase(100, 20, 2, 9.894)]
        [TestCase(100, 30, 2, 10.042)]
        [TestCase(100, 40, 2, 10.095)]
        [TestCase(100, 50, 2, 10.099)]
        [TestCase(100, 60, 2, 10.057)]
        [TestCase(100, 70, 2, 9.937)]
        [TestCase(100, 80, 2, 9.564)]
        [TestCase(100, 90, 2, 5.227)]
        [TestCase(100, 1, 5, -39.244)]
        [TestCase(100, 10, 5, 19.532)]
        [TestCase(100, 10, 9, 25.751)]
        [TestCase(100, 20, 9, 35.946)]
        public void Zfunction_ForGivenValues_ShouldReturnExpectedResult(double linear, int angle, int tetha, double expected)
        {
            var sut = new GeometrySKP();
            sut.Parameters[0].Value = linear;
            sut.Parameters[1].Value = tetha;

            var res = Math.Round(sut.ZFunction(angle), 3);

            Assert.That(res, Is.EqualTo(expected));
        }
    }
}
