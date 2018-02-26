using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster_Algorithm
{
    /// <summary>
    /// A simple Class that holds ClusterPairs and their distances from each other.
    /// </summary>
    public class ClusterPair
    {
        public int clusterOne;
        public int clusterTwo;
        public float distance;

    }

    /// <summary>
    /// Class that holds a list of datapoints and calculates the distance between its points.
    /// </summary>
    public class Cluster
    {
        private List<DataPoint> dataList; //List of Data Points

        /// <summary>
        /// Initiliazes a constructor which creates a new list of dataPoints.
        /// </summary>
        public Cluster()
        {
            dataList = new List<DataPoint>();
        }

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


        /// <summary>
        /// Get DataListPoint
        /// </summary>
        /// <returns></returns>
        public List<DataPoint> GetDataPoints()
        {
            return dataList;
        }

        /// <summary>
        /// Merges two clusters by having this cluster take all datapoints from the other cluster.
        /// </summary>
        public void MergeCluster(Cluster otherCluster) 
        {
            for(int i = 0; i < otherCluster.GetDataPoints().Count; i++)
            {
                dataList.Add(otherCluster.GetDataPoints()[i]);
            }
        }
    }
}
