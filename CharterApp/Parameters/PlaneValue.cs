using CharterApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharterApp.Models
{
    public class PlaneValue : IParametr
    {
        public string Name => "hkl";

        public string Unit => "";

        public double Value { get; set; }

        public bool Validate()
        {
            return Value >= 999 && Value <= 100;
        }
    }
}
