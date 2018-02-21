using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster_Algorithm
{
    /// <summary>
    /// Class that holds a list of datapoints and calculates the distance between its points.
    /// </summary>
    public class Cluster
    {
        private List<DataPoint> dataList;

        /// <summary>
        /// Initializes a constructor which creates a new list of dataPoints and add 
        /// newDataPoint to that list.
        /// </summary>
        /// <param name="newDataPoint"></param>
        public Cluster(DataPoint newDataPoint)
        {
            dataList = new List<DataPoint>();
            dataList.Add(newDataPoint);
        }
    }
}
