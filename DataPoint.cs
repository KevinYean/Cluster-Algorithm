using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster_Algorithm
{
    public class DataPoint
    {
        int oneDimensionVar; //Test Variable
        string oneDimensionAttri; //Test Variable

        /// <summary>
        /// Initializes a newly created DataPoint with just one variable.
        /// </summary>
        /// <param name="newOneDimensionVar"></param>
        /// <param name="newOneDimensionAttri"></param>
        public DataPoint(int newOneDimensionVar,string newOneDimensionAttri)
        {
            oneDimensionVar = newOneDimensionVar;
            oneDimensionAttri = newOneDimensionAttri;
        }

    }
}
