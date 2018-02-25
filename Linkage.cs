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
        public List<ClusterPair> listClusterPairs;

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
            listClusterPairs = new List<ClusterPair>();
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
        /// Create all ClusterPairs
        /// </summary>
        public void CreateClusterPairs()
        {
            listClusterPairs = new List<ClusterPair>(); //Reset everytime.
            //n(n - 1) / 2
            for (int i = 0; i < clusterList.Count; i++)
            {
                for (int y = i + 1; y < clusterList.Count; y++)
                {
                    ClusterPair tempClusterPair = new ClusterPair();
                    tempClusterPair.clusterOne = i;
                    tempClusterPair.clusterTwo = y;
                    listClusterPairs.Add(tempClusterPair);
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
            foreach (ClusterPair pair in listClusterPairs)
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
            return listClusterPairs.Count();
        }

        /// <summary>
        /// Set the ClusterPairDistances for all clusterPairs
        /// </summary>
        public void SetClusterPairsDistances()
        {
            //Might need to switch foreach to for int, unclear if clusterpair directely refers to references.
            for(int x = 0; x < listClusterPairs.Count; x++)
            {
                int clusterOne = listClusterPairs[x].clusterOne;
                int clusterTwo = listClusterPairs[x].clusterTwo;
                float distance = -1;
                //Go through every datapoint in cluster one
                for(int i = 0; i < clusterList[clusterOne].GetDataPoints().Count; i++)
                {
                    //Go through everydatapoint in cluster two
                    for(int y = 0; y < clusterList[clusterTwo].GetDataPoints().Count; y++)
                    {
                        float tempDistance = clusterList[clusterOne].GetDataPoints()[i].GetDistanceDataPoint(clusterList[clusterTwo].GetDataPoints()[y].GetValues());
                        //Closest
                        if (tempDistance < distance || distance == -1){
                            distance = tempDistance;
                        }
                    }
                }
                listClusterPairs[x].distance = distance;
            }
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
            float distance = -1;

            for (int x = 0; x < listClusterPairs.Count; x++)
            {
                if (listClusterPairs[x].distance < distance || distance == -1)
                {
                    clusterOne = listClusterPairs[x].clusterOne;
                    clusterTwo = listClusterPairs[x].clusterTwo;
                    distance = listClusterPairs[x].distance;
                }
            }

            clusterList[clusterOne].MergeCluster(clusterList[clusterTwo]); //Merge
            clusterList.RemoveAt(clusterTwo);//Remove second cluster from list.
        }

        /// <summary>
        /// Return a representation of the cluster in a string format.
        /// </summary>
        /// <returns></returns>
        public string ClustersToString()
        {
            string toString = "";
            foreach(Cluster cluster in clusterList)
            {
                toString += "Cluster: \n";
                foreach(DataPoint data in cluster.GetDataPoints())
                {
                    toString += "Data: ";
                    foreach (float value in data.GetValues())
                    {
                        toString += value + " , ";
                    }
                    toString += data.GetLabel();
                    toString += "\n";
                }
            }
            return toString;
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
