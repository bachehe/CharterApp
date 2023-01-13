using CharterApp.Tests.Attribute;
using CharterApp.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharterApp.Tests.ViewModels
{
    [TethaValueCalculate]
    public class TethaValueCalculateViewModelTests
    {
        [Test]
        [TestCase(2, 1, 28.96)]
        [TestCase(10, 15, 97.180)]
        [TestCase(61, 43, 41.280)]
        [TestCase(77, 71, 54.900)]
        [TestCase(11, 5, 26.280)]
        public void CalculateTehta_ForGivenValues_ShouldReturnExpectedResult(double dhkl, double lambda, double expected)
        {
            var sut = new TethaValueCalculateViewModel();
            sut.Dhkl = dhkl;
            sut.LambdaValue = lambda;

            sut.CalculateCommand.Execute(null);

            Assert.AreEqual(expected/2, Math.Round(sut.Result,3));
        }
    }
}
