using NUnit.Framework;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharterApp.Tests.Attribute
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class GeometryBBAttribute : CategoryAttribute
    {
    }
}
