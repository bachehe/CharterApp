using CharterApp.Models;
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
    public class GraphViewModelTests
    {
        [Test]
        public void DrawMethod() // TODO: refactor
        {
            var mockGeometryType = new Mock<IGeometry>();
            mockGeometryType.Setup(x => x.ZFunction(0)).Returns(0);

            var mockGraphModel = new Mock<IGraphViewModel>();
            mockGraphModel.Setup(x => x.Draw(mockGeometryType.Object));

            mockGraphModel.CallBase = true;

            mockGraphModel.VerifyNoOtherCalls();
        }
    }
}
