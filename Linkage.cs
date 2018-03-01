using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster_Algorithm
{
    public class Linkage
    {
        public int kClusters;
        public List<DataPoint> dataList;
        public List<Cluster> clusterList;
        public List<ClusterPair> clusterPairsList;

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
            clusterPairsList = new List<ClusterPair>();
            kClusters = newK;
            dataList = new List<DataPoint>(newDataList);
            clusterList = new List<Cluster>();
        }

        /// <summary>
        /// Initializes the clusters so that each point is in its own cluster
        /// and add it to the list of clusters.
        /// </summary>
        public void CreateInitClusters()
        {
            foreach(DataPoint dataPoint in dataList)
            {
                Cluster temporaryCluster = new Cluster(dataPoint);
                clusterList.Add(temporaryCluster);
            }
        }

        /// <summary>
        /// Return a representation of the cluster in a string format.
        /// </summary>
        /// <returns></returns>
        public string ClustersToString()
        {
            string toString = "";
            foreach (Cluster cluster in clusterList)
            {
                toString += "Cluster: \n";
                foreach (DataPoint data in cluster.GetDataPoints())
                {
                    toString += "Data: ";
                    toString += data.ToString();
                    toString += "\n";
                }
            }
            return toString;
        }

        public string ClusterGroupToString()
        {
            string toString = "";
            foreach (Cluster cluster in clusterList)
            {
                toString += "Cluster: \n";
                IEnumerable<IGrouping<string, DataPoint>> query = cluster.GetDataPoints().GroupBy(data => data.GetLabel());
                foreach (IGrouping<string, DataPoint> points in query)
                {
                    string test = points.Key;
                    toString += (test + "--Point Count: " +  points.Count() + "\n");
                }
                toString += "\n";
            }
            return toString;
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
        /// Returns the list of clusters clusterlist.
        /// </summary>
        /// <returns></returns>
        public List<Cluster> GetClusters()
        {
            return clusterList;
        }

        /// <summary>
        /// Create all ClusterPairs
        /// </summary>
        public void CreateClusterPairs()
        {
            clusterPairsList = new List<ClusterPair>(); //Reset everytime.
            //n(n - 1) / 2
            for (int i = 0; i < clusterList.Count; i++)
            {
                for (int y = i + 1; y < clusterList.Count; y++)
                {
                    ClusterPair tempClusterPair = new ClusterPair();
                    tempClusterPair.clusterOne = i;
                    tempClusterPair.clusterTwo = y;
                    clusterPairsList.Add(tempClusterPair);
                }
            }
        }

        /// <summary>
        /// Returns ClusterPairs as a string.
        /// </summary>
        /// <returns></returns>
        public string ClusterPairsToString()
        {
            string toString = "";
            foreach (ClusterPair pair in clusterPairsList)
            {
                toString += "Cluster Pair: [" + pair.clusterOne + "][" + pair.clusterTwo + "], Distance: "+ pair.distance + "\n"; 
            }
            return toString;
        }

        /// <summary>
        ///Returns the number of clusterPairs;
        /// </summary>
        /// <returns></returns>
        public int GetClusterPairsCount()
        {
            return clusterPairsList.Count();
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
        /// Merges Closest Clusters together
        /// </summary>
        public void MergeClusters()
        {
            int clusterOne = -1;
            int clusterTwo = -1;
            float distance = -1f;

            for (int x = 0; x < clusterPairsList.Count; x++)
            {
                if (clusterPairsList[x].distance < distance || distance == -1f)
                {
                    clusterOne = clusterPairsList[x].clusterOne;
                    clusterTwo = clusterPairsList[x].clusterTwo;
                    distance = clusterPairsList[x].distance;
                }
            }
            clusterList[clusterOne].MergeCluster(clusterList[clusterTwo]); //Merge
            clusterList.RemoveAt(clusterTwo);//Remove second cluster from list.
            //Console.WriteLine("Distance: " + distance);
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
