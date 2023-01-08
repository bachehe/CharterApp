using System;
using System.Collections.Generic;
using System.IO;

namespace CharterApp.Calculate
{
    public static class Data
    {
        public static List<decimal> Densities { get; }
        public static List<decimal> MoValues { get; }
        public static List<decimal> CuValues { get; }
        public static List<decimal> CoValues { get; }
        public static List<decimal> CrValues { get; }

        static Data()
        {
            Densities = new();
            MoValues = new();
            CuValues = new();
            CoValues = new();
            CrValues = new();

            var filePath = "./Data/basecsv.csv";

            foreach (var line in File.ReadAllLines(filePath))
            {
                var values = line.Split(';');

                var density = decimal.Parse(values[0]);
                var mo = decimal.Parse(values[1]);
                var cu = decimal.Parse(values[2]);
                var co = decimal.Parse(values[3]);
                var cr = decimal.Parse(values[4]);

                Densities.Add(density);
                MoValues.Add(mo);
                CuValues.Add(cu);
                CoValues.Add(co);
                CrValues.Add(cr);
            }
        }
    }
}
