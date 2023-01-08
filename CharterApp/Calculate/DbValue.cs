using CharterApp.Lamps;
using System.Collections.Generic;

namespace CharterApp
{
    public class DbValue
    {
        private Dictionary<LampEnum, decimal> _kalfas;

        public string Element { get; }
        public decimal ElementDensity { get; }

        public decimal this[LampEnum lamp] => _kalfas[lamp];

        public DbValue(string element, decimal elementDensity, params (LampEnum lamp, decimal kalfa)[] kalfas)
        {
            Element = element;
            ElementDensity = elementDensity;

            _kalfas = new();
            foreach (var kalfa in kalfas)
                _kalfas[kalfa.lamp] = kalfa.kalfa;
        }
    }
}
