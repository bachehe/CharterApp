using CharterApp.Models;
using CharterApp.Tests.Attribute;
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
    [Graph]
    public class GraphViewModelTests
    {
        [Test]
        public void Draw_VeryfingMethods()
        {
            var mockGeometry = new Mock<IGeometry>();
            mockGeometry.SetupAllProperties();
            mockGeometry.Setup(x => x.ZFunction(It.IsAny<int>())).Returns(2);
            mockGeometry.Setup(x => x.LegendLabel).Returns("Test Label");

            var mockGraphModel = new Mock<IGraphViewModel>();
            mockGraphModel.Object.Draw(mockGeometry.Object);

            mockGraphModel.Verify(x => x.Draw(mockGeometry.Object), Times.Once());
            mockGraphModel.VerifyNoOtherCalls();
        }
    }
}
