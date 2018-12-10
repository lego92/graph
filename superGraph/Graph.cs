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
        public string ChartArea { get; set; }

        double sampleTime;
        public double SampleTime
        {
            get
            {
                return sampleTime;
            }
            set
            {
                sampleTime = value * 1e-3;
            }
        }

        public List<double> Samples { get; set; }       

        public Graph(string name, string chartArea)
        {
            Name = name;
            ChartArea = chartArea;
            SampleTime = 1.25;
            Samples = new List<double>();
        }

        public Graph(string name, string chartArea, double sampleTime)
        {
            Name = name;
            ChartArea = chartArea;
            SampleTime = sampleTime;
            Samples = new List<double>();
        }
    }
}
