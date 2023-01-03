using CharterApp.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharterApp.Tests.ViewModels
{
    public class TethaValueCalculateViewModelTests
    {
        [Test]
        [TestCase(1, 1, 2.377)]
        [TestCase(10, 15, 2.005)]
        [TestCase(61, 43, 3.087)]
        [TestCase(71, 77, 2.262)]
        [TestCase(5, 11, 2.474)]
        public void CalculateTehta_ForGivenValues_ShouldReturnExpectedResult(double dhkl, double lambda, double expected)
        {
            var sut = new TethaValueCalculateViewModel();
            sut.Dhkl = dhkl;
            sut.LambdaValue = lambda;

            sut.CalculateCommand.Execute(null);

            Assert.AreEqual(expected, Math.Round(sut.Result,3));
        }
    }
}
