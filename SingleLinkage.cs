using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster_Algorithm
{
    /// <summary>
    /// Minimum distance between clusters algorithm
    /// </summary>
    public class SingleLinkage : Linkage
    {
        /// <summary>
        /// Constructor will call Linkage.Linkage().
        /// </summary>
        public SingleLinkage() : base()
        {

        }

        /// <summary>
        /// Constructor will call Linkage.Linkage(int newK, List<DataPoint> newDataList);
        /// </summary>
        /// <param name="newK"></param>
        /// <param name="newDataList"></param>
        public SingleLinkage(int newK, List<DataPoint> newDataList) : base(newK, newDataList)
        {

        }

        /// <summary>
        /// Runs Single Linkage
        /// </summary>
        public void Run()
        {
            //Put each value into their own clusters
            CreateInitClusters();
            //Run as long as the number of clusters is not k
            while (clusterList.Count() > kClusters)
            {
                CreateClusterPairs(); //Create Cluster Pairs
                SetClusterPairsSingleLinkageDistances(); //Calculate Cluster Pairs distances
                MergeClusters(); //Merge the two closest clusters
            }

            //TO ERASE
            clusterList[0].CreateDataPointPairs();
            clusterList[0].SetDataPairsDistances();
            clusterList[0].SetCentroidPoint();
            Console.WriteLine(clusterList[0].DataPairsToString());
            Console.WriteLine(clusterList[0].GetCentroidPoint().ToStringValues());
            ///
        }

        /// <summary>
        /// Set the ClusterPairDistances for all clusterPairs
        /// </summary>
        public void SetClusterPairsSingleLinkageDistances()
        {
            //Might need to switch foreach to for int, unclear if clusterpair directely refers to references.
            for (int x = 0; x < clusterPairsList.Count; x++)
            {
                int clusterOne = clusterPairsList[x].clusterOne;
                int clusterTwo = clusterPairsList[x].clusterTwo;
                float distance = -1;
                //Go through every datapoint in cluster one
                for (int i = 0; i < clusterList[clusterOne].GetDataPoints().Count; i++)
                {
                    //Go through every datapoint in cluster two
                    for (int y = 0; y < clusterList[clusterTwo].GetDataPoints().Count; y++)
                    {
                        float tempDistance = clusterList[clusterOne].GetDataPoints()[i].GetDistanceDataPoint(clusterList[clusterTwo].GetDataPoints()[y].GetValues());
                        //Closest
                        if (tempDistance < distance || distance == -1)
                        {
                            distance = tempDistance;
                        }
                    }
                }
                clusterPairsList[x].distance = distance;
            }
        }

        /// <summary>
        /// Merges Closest Clusters together
        /// </summary>
        public void MergeClusters()
        {
            int clusterOne = -1;
            int clusterTwo = -1;
            float distance = -1;

            for (int x = 0; x < clusterPairsList.Count; x++)
            {
                if (clusterPairsList[x].distance < distance || distance == -1)
                {
                    clusterOne = clusterPairsList[x].clusterOne;
                    clusterTwo = clusterPairsList[x].clusterTwo;
                    distance = clusterPairsList[x].distance;
                }
            }
            clusterList[clusterOne].MergeCluster(clusterList[clusterTwo]); //Merge
            clusterList.RemoveAt(clusterTwo);//Remove second cluster from list.
        }

    }
}
