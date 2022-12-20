using System.Collections.Generic;
using System.IO;

namespace CharterApp.Calculate
{
    public static class Data
    {
        public static List<double> Densities { get; } 
        public static List<double> MoValues { get; }
        public static List<double> CuValues { get; }
        public static List<double> CoValues { get; }
        public static List<double> CrValues { get; }

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

                var density = double.Parse(values[0]);
                var mo = double.Parse(values[1]);
                var cu = double.Parse(values[2]);
                var co = double.Parse(values[3]);
                var cr = double.Parse(values[4]);

                Densities.Add(density);
                MoValues.Add(mo);
                CuValues.Add(cu);
                CoValues.Add(co);
                CrValues.Add(cr);
            }
        }
    }
}
