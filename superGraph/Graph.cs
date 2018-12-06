using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace superGraph
{
    class Graph
    {
        public string Name { get; set; }
        public int ChartArea { get; set; }

        public double SampleTime { get; set; }

        public List<double> Samples { get; set; }



        //public double this[int index]
        //{
        //    get { return samples[index]; }
        //    set { samples[index] = value; }
        //}

        public Graph(string name, int chartArea)
        {
            Name = name;
            ChartArea = chartArea;
            SampleTime = 1.25 * 1e-3;
            Samples = new List<double>();
        }
    }
}
