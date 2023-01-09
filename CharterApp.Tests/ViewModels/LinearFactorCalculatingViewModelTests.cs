using CharterApp.Lamps;
using CharterApp.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharterApp.Tests.ViewModels
{
    public class LinearFactorCalculatingViewModelTests
    {  
        [Test]
        [TestCase("Cu", "Zn", 0.7, 0.3, LampEnum.Co, 8.6, 699.094)]
        [TestCase("H", "He", 0.5, 0.5, LampEnum.Mo, 1.85, 0.5324)]
        [TestCase("Li", "Be", 0.2, 0.8, LampEnum.Cr, 2.27, 6.3446)]
        [TestCase("Si", "Cl", 0.4, 0.6, LampEnum.Cu, 4.51, 413.3325)]
        public void CalculateTest_For2Elements_ShouldReturnExpectedResult(string element1, string element2, decimal perc1, decimal perc2, LampEnum lampEnumer,  decimal density, decimal expected)
        {
            var sut = new LinearFactorCalculatingViewModel();
            var elements = new LampElement() { Element=element1, Percentage = perc1 };
            sut.Elements.Add(elements);

            elements = new LampElement() { Element = element2, Percentage = perc2 };
            sut.Elements.Add(elements);

            sut.Lamp = new Lamp(lampEnumer);
            sut.Density = density;
            sut.CalculateCommand.Execute(null);

            Assert.AreEqual(expected, sut.Result); 
        }

        [Test]
        [TestCase("Cu", "Zn", "H", "Sn", 0.3, 0.3, 0.2, 0.2, LampEnum.Co, 8.6, 1074.5298)]
        [TestCase("H", "He", "Li", "Ti", 0.2, 0.5, 0.1, 0.2, LampEnum.Mo, 1.85, 8.9639)]
        [TestCase("Li", "Be", "Co", "Br", 0.1, 0.1, 0.2, 0.6, LampEnum.Cr, 2.27, 420.1375)]
        [TestCase("Si", "Cl", "C", "N", 0.3, 0.5, 0.1, 0.1, LampEnum.Cu, 4.51, 339.7478)]
        public void CalculateTest_For4Elements_ShouldReturnExpectedResult(string element1, string element2, string element3, string element4, decimal perc1, decimal perc2, decimal perc3, decimal perc4, LampEnum lampEnumer, decimal density, decimal expected)
        {
            var sut = new LinearFactorCalculatingViewModel();
            var elements = new LampElement() { Element = element1, Percentage = perc1 };
            sut.Elements.Add(elements);

            elements = new LampElement() { Element = element2, Percentage = perc2 };
            sut.Elements.Add(elements);

            elements = new LampElement() { Element = element3, Percentage = perc3 };
            sut.Elements.Add(elements);

            elements = new LampElement() { Element = element4, Percentage = perc4 };
            sut.Elements.Add(elements);

            sut.Lamp = new Lamp(lampEnumer);
            sut.Density = density;
            sut.CalculateCommand.Execute(null);

            Assert.AreEqual(expected, sut.Result);
        }
        [Test]
        [TestCase("Cu", "Zn", "H", "Sn", "Li", "Be", 0.2, 0.2, 0.3, 0.1, 0.1, 0.1, LampEnum.Co, 8.6, 611.5553)]
        [TestCase("H", "He", "Li", "Ti", "C", "V", 0.2, 0.3, 0.1, 0.2, 0.1, 0.1, LampEnum.Mo, 1.85, 13.6576)]
        [TestCase("Li", "Be", "Co", "Br", "Si", "Cu", 0.1, 0.2, 0.1, 0.1, 0.2, 0.3, LampEnum.Cr, 2.27, 288.1558)]
        [TestCase("Si", "Cl", "C", "N", "Zn", "Mn", 0.1, 0.3, 0.3, 0.1, 0.1, 0.1, LampEnum.Cu, 4.51, 335.8728)]
        public void CalculateTest_For6Elements_ShouldReturnExpectedResult(string element1, string element2, string element3, string element4, string element5, string element6, decimal perc1, decimal perc2, decimal perc3, decimal perc4, decimal perc5, decimal perc6, LampEnum lampEnumer, decimal density, decimal expected)
        {
            var sut = new LinearFactorCalculatingViewModel();
            var elements = new LampElement() { Element = element1, Percentage = perc1 };
            sut.Elements.Add(elements);

            elements = new LampElement() { Element = element2, Percentage = perc2 };
            sut.Elements.Add(elements);

            elements = new LampElement() { Element = element3, Percentage = perc3 };
            sut.Elements.Add(elements);

            elements = new LampElement() { Element = element4, Percentage = perc4 };
            sut.Elements.Add(elements);

            elements = new LampElement() { Element = element5, Percentage = perc5 };
            sut.Elements.Add(elements);

            elements = new LampElement() { Element = element6, Percentage = perc6 };
            sut.Elements.Add(elements);

            sut.Lamp = new Lamp(lampEnumer);
            sut.Density = density;
            sut.CalculateCommand.Execute(null);

            Assert.AreEqual(expected, sut.Result);
        }

        [Test]
        [TestCase("Cu", "Zn", "H", "Sn", "Li", "Be", "Be", "Co", "Br", "Si", 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, LampEnum.Co, 8.6, 728.5745)]
        [TestCase("H", "He", "Li", "C", "V", "Be", "Co", "Br", "Si", "Cu", 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, LampEnum.Mo, 1.85, 36.6976)]
        [TestCase("Be", "Co", "Br", "Si", "Cu", "Li", "C", "V", "Zn", "Co", 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, LampEnum.Cr, 2.27, 258.5385)]
        [TestCase("Si", "Cl", "C", "N", "Zn", "Mn", "Li", "Be", "Co", "Br", 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, LampEnum.Cu, 4.51, 427.6675)]
        public void CalculateTest_For10Elements_ShouldReturnExpectedResult(string element1, string element2, string element3, string element4, string element5, string element6, string element7, string element8,string element9, string element10, decimal perc1, decimal perc2, decimal perc3, decimal perc4, decimal perc5, decimal perc6, decimal perc7, decimal perc8, decimal perc9, decimal perc10, LampEnum lampEnumer, decimal density, decimal expected)
        {
            var sut = new LinearFactorCalculatingViewModel();
            var elements = new LampElement() { Element = element1, Percentage = perc1 };
            sut.Elements.Add(elements);

            elements = new LampElement() { Element = element2, Percentage = perc2 };
            sut.Elements.Add(elements);

            elements = new LampElement() { Element = element3, Percentage = perc3 };
            sut.Elements.Add(elements);

            elements = new LampElement() { Element = element4, Percentage = perc4 };
            sut.Elements.Add(elements);

            elements = new LampElement() { Element = element5, Percentage = perc5 };
            sut.Elements.Add(elements);

            elements = new LampElement() { Element = element6, Percentage = perc6 };
            sut.Elements.Add(elements);

            elements = new LampElement() { Element = element7, Percentage = perc7 };
            sut.Elements.Add(elements);

            elements = new LampElement() { Element = element8, Percentage = perc8 };
            sut.Elements.Add(elements);

            elements = new LampElement() { Element = element9, Percentage = perc9 };
            sut.Elements.Add(elements);

            elements = new LampElement() { Element = element10, Percentage = perc10 };
            sut.Elements.Add(elements);

            sut.Lamp = new Lamp(lampEnumer);
            sut.Density = density;
            sut.CalculateCommand.Execute(null);

            Assert.AreEqual(expected, sut.Result);
        }
    }
}
