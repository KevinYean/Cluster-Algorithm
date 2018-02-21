using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster_Algorithm
{
    public class Linkage
    {
        private int kClusters;
        private List<DataPoint> dataList;
        private List<Cluster> clusterList;

        /// <summary>
        /// Initalizes a newly created Linkage
        /// </summary>
        public Linkage()
        {
            clusterList = new List<Cluster>();
        }

        /// <summary>
        /// Initializes a newly created Linkage with the number of clusters it should have at the end and 
        /// a list of DataPoints.
        /// </summary>
        /// <param name="newK"></param>
        /// <param name="newDataList"></param>
        public Linkage(int newK, List<DataPoint> newDataList)
        {
            kClusters = newK;
            dataList = new List<DataPoint>(newDataList);
            clusterList = new List<Cluster>();
        }

        /// <summary>
        /// Initializes the clusters so that each point is in its own cluster
        /// and add it to the list of clusters.
        /// </summary>
        public void CreateClusters()
        {
            foreach(DataPoint dataPoint in dataList)
            {
                Cluster temporaryCluster = new Cluster(dataPoint);
                clusterList.Add(temporaryCluster);
            }
        }

        /// <summary>
        /// Returns the number of clusters in clusterList.
        /// </summary>
        /// <returns></returns>
        public int GetClustersCount()
        {
            return clusterList.Count;
        }

        /// <summary>
        /// Returns the number of clusters assigned to Linkage.
        /// </summary>
        /// <returns></returns>
        public int GetK()
        {
            return kClusters;
        }


        /// <summary>
        /// Test Inheritance Method by returning -1.
        /// </summary>
        /// <returns></returns>
        public int TestInheritance()
        {
            return -1;
        }
    }

}
