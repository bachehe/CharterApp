using CharterApp.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharterApp.Tests.ViewModels
{
    public class LinearFactorCalculatingTests
    {
        [Test]
        [TestCase(1.85, 0.3, 0, 0, 0, 0.136)]
        [TestCase(1.85, 0.3, 0.1, 0, 0.2, 1.5)]
        [TestCase(1.85, 0.3, 0.3, 0, 0, 0.6949)]
        [TestCase(1.85, 0.1, 0, 0, 0.4, 2.4008)]
        [TestCase(1.85, 0.7, 0, 0.2, 0, 0.8805)]
        [TestCase(1.85, 0.1, 0.1, 0.1, 0.1, 1.1021)]
        public void CalculateLinearFactor_ForGivenValues_ShouldReturnExpectedResult(decimal density, decimal mo, decimal cu, decimal co, decimal cr, decimal expected)
        {
            var sut = new LinearFactorCalculatingViewModel();
            sut.Density = density;
            sut.MoPercentage = mo;
            sut.CuPercentage = cu;
            sut.CoPercentage = co;
            sut.CrPercentage = cr;

            sut.CalculateCommand.Execute(null);

            Assert.AreEqual(expected, sut.LinearFactor);
        }
        
        [Test]
        [TestCase(1.85, 0.3, 0, 0, 0, 0.7)]
        [TestCase(1.85, 0.3, 0.1, 0, 0.2, 0.4)]
        [TestCase(1.85, 0.3, 0.3, 0, 0, 0.4)]
        [TestCase(1.85, 0.1, 0, 0, 0.4, 0.5)]
        [TestCase(1.85, 0.7, 0, 0.2, 0, 0.1)]
        [TestCase(1.85, 0.1, 0.1, 0.1, 0.1, 0.6)]
        public void FePercentage_ForGivenPercentages_ShouldReturnRestToHundredPercent(decimal density, decimal mo, decimal cu, decimal co, decimal cr, decimal expected)
        {
            var sut = new LinearFactorCalculatingViewModel();
            sut.Density = density;
            sut.MoPercentage = mo;
            sut.CuPercentage = cu;
            sut.CoPercentage = co;
            sut.CrPercentage = cr;

            sut.CalculateCommand.Execute(null);

            Assert.AreEqual(expected, sut.FePercentage);
        }
    }
}
