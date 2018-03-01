using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster_Algorithm
{
    /// <summary>
    /// Minimum between-Cluster distance.
    /// </summary>
    public class AverageLinkage : Linkage
    {
        /// <summary>
        /// Constructor will call Linkage.Linkage().
        /// </summary>
        public AverageLinkage() : base()
        {

        }

        /// <summary>
        /// Constructor will call Linkage.Linkage(int newK, List<DataPoint> newDataList);
        /// </summary>
        /// <param name="newK"></param>
        /// <param name="newDataList"></param>
        public AverageLinkage(int newK, List<DataPoint> newDataList) : base(newK, newDataList)
        {

        }

                /// <summary>
        /// Runs Average Linkage
        /// </summary>
        public void Run()
        {
            //Put each value into their own clusters
            CreateInitClusters();
            //Console.WriteLine(ClustersToString());
            //Console.ReadLine();
            //Run as long as the number of clusters is not k
            while (clusterList.Count() > kClusters)
            {
                CreateClusterPairs(); //Create Cluster Pairs
                //Console.WriteLine(ClustersToString());
                SetClusterPairsAverageDistances(); //Calculate Cluster Pairs distances
                //Console.WriteLine(ClusterPairsToString());
                MergeClusters(); //Merge the two closest clusters
                //Console.WriteLine();
                //Console.ReadLine();
            }
        }

        /// <summary>
        /// Set the ClusterAveraegDistance for all clusterPairs
        /// </summary>
        public void SetClusterPairsAverageDistances()
        {
            //Might need to switch foreach to for int, unclear if clusterpair directely refers to references.
            for (int x = 0; x < clusterPairsList.Count; x++)
            {
                int clusterOne = clusterPairsList[x].clusterOne;
                int clusterTwo = clusterPairsList[x].clusterTwo;
                int clusterOneSize = clusterList[clusterOne].GetDataPoints().Count();
                int clusterTwoSize = clusterList[clusterTwo].GetDataPoints().Count();
                float distance = 0f;
                //Go through every datapoint in cluster one
                for (int i = 0; i < clusterOneSize; i++)
                {
                    //Go through every datapoint in cluster two and add to total distance
                    for (int y = 0; y < clusterTwoSize ; y++)
                    {
                        float tempDistance = clusterList[clusterOne].GetDataPoints()[i].GetDistanceDataPoint(clusterList[clusterTwo].GetDataPoints()[y].GetValues());
                        distance += tempDistance;

                    }
                }

                //Console.WriteLine("Total Distance: " + distance);
                distance = (1f / (clusterOneSize * clusterTwoSize)) * distance;
                //Console.WriteLine("Avg Distance: " + distance);
                clusterPairsList[x].distance = distance;
            }
        }
    }
}
