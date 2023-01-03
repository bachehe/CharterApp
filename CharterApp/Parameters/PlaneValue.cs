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

        public string StringValue => Value.ToString().PadLeft(3, '0');

        public bool Validate()
        {
            return Value >= 0 && Value <= 999;
        }
    }
}
