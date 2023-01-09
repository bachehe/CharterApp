using CharterApp.ViewModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharterApp.Tests.ViewModels
{
    public class CalculateAbsorptionViewModelTests
    {
        [Test]
        [TestCase(10, 5, 0.5, 1.386)]
        [TestCase(10, 5, 100, 0.007)]
        [TestCase(120, 10, 60, 0.041)]
        public void CalculateAbsorption_ForGivenValues_ShouldReturnExpectedResult(double Jo, double Jx, double linear, double expected)
        {
            var sut = new CalculateAbsorptionViewModel();
            sut.ValueJo = Jo;
            sut.ValueJx = Jx;
            sut.LinearFactor = linear;

            sut.CalculateCommand.Execute(null);

            Assert.AreEqual(expected, Math.Round(sut.Result, 3));
        }
    }
}
