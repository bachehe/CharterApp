using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using CsvHelper;
using CsvHelper.Configuration.Attributes;

namespace CharterApp.Calculate
{
    public class LinearFactorCalculate
    {
        public List<double> Density { get; set; } 
        public LinearFactorCalculate()
        {
            Density = new();
        }

        public List<double> DensityList { get; set; }
        public void CsvReader()
        {
            string filePath = "basecsv.csv";
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(';');

                    double density = double.Parse(values[0]);
                    double mo = double.Parse(values[1]);
                    double cu = double.Parse(values[2]);
                    double co = double.Parse(values[3]);
                    double cr = double.Parse(values[4]);

                    Density.Add(density);
                }
            }
        }
    }
}
