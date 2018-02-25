using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster_Algorithm
{
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
                //Console.WriteLine(this == otherCluster);
                //Console.WriteLine(dataList[i].GetValues()[i]);
                //Console.WriteLine(otherCluster.dataList[i].GetValues()[i]);
                dataList.Add(otherCluster.GetDataPoints()[i]);
            }
            /*foreach(DataPoint point in otherCluster.GetDataPoints())
            {
                dataList.Add(point); //To do create brand new datapoint?
            }*/
        }
    }
}
