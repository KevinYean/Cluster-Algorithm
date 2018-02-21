using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster_Algorithm
{
    class Start
    {
        static void Main(string[] args)
        {
            Start main = new Start();
        }

        public Start()
        {
            Console.WriteLine("Start");
            FileReader fileReader = new FileReader();
            fileReader.ReadCSVFile(@"..\..\Sample1D.csv");
            fileReader.ConvertDataString();
            

            Console.ReadLine();
        }
    }
}
