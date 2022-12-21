using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharterApp.ViewModels
{
    public class DataBaseViewModel
    {
        public List<decimal> Density { get; set; }
        public List<decimal> Mo { get; set; }
        public List<decimal> Cu { get; set; }
        public List<decimal> Co { get; set; }
        public List<decimal> Cr { get; set; }

        public DataBaseViewModel()
        {
            Density = new List<decimal>();
            Mo = new List<decimal>();
            Cu = new List<decimal>();
            Co = new List<decimal>();
            Cr = new List<decimal>();

        }
    }
}
