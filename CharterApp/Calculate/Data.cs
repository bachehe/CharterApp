using CharterApp.Lamps;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace CharterApp
{
    public static class Data
    {
        public static IReadOnlyDictionary<string, DbValue> Values { get; }

        static Data()
        {
            var map = new Dictionary<string, DbValue>();

            var filePath = "./Data/newbase.csv";

            foreach (var line in File.ReadAllLines(filePath))
            {
                var values = line.Split(';');

                var elName = values[0];
                var density = decimal.Parse(values[1]);
                var mo = decimal.Parse(values[2]);
                var cu = decimal.Parse(values[3]);
                var co = decimal.Parse(values[4]);
                var cr = decimal.Parse(values[5]);

                var dbValue = new DbValue(elName, density, (LampEnum.Mo, mo), (LampEnum.Cu, cu), (LampEnum.Co, co), (LampEnum.Cr, cr));
                map[elName] = dbValue;
            }

            Values = new ReadOnlyDictionary<string, DbValue>(map);
        }
    }
}
