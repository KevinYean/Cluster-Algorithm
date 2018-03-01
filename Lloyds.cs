using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster_Algorithm
{
    public class Lloyds
    {
        public int kClusters;
        public List<DataPoint> dataList;
        public List<Cluster> clusterList;
        public List<Cluster> bestClusterList;
        private int convergence;
        private float kMean;

        /// <summary>
        /// Initializes constructor for Lloyds method also called k-mean
        /// </summary>
        public Lloyds(int newKClusters, List<DataPoint> newDataList)
        {
            kClusters = newKClusters;
            dataList = new List<DataPoint>(newDataList);
            bestClusterList = new List<Cluster>();
            convergence = 2;
            kMean = -1;
        }

        /// <summary>
        /// Method runs Lloyds Method for clustering
        /// </summary>
        /// <param name="loops"></param>
        public void Run(int loops)
        {
            //Run many times as loops was set
            for (int i = 0; i < loops; i++)
            {
                //Pick k random points (call them centers)
                System.Threading.Thread.Sleep(10); //To reduce the odds of having the same seed be used to generate random numbers.
                convergence = 2;
                SetKCenter();
                //Until convergence
                while (convergence != 0)
                {
                    EmptyClusters(); //Remove all datapoints in all clusters.
                    //Assign each point to its closest center
                    SetPointsToCluster();
                    //Compute the mean of each cluster
                    foreach (Cluster cluster in clusterList)
                    {
                        cluster.SetCentroidPoint();
                    }
                    //Checks if any centers have changed and sets the appropriate flags.
                    IsClusterCenterChanged();
                }
                float tempKmean = GetKMeanCost();
                //New K-mean objective cost
                if (kMean == -1 || tempKmean <kMean)
                {
                    //Console.WriteLine("New Lowest K Mean: " + tempKmean); //To remove
                    kMean = tempKmean;
                    bestClusterList = new List<Cluster>(clusterList); //Save the current best list of clusters.
                }       
            }
        }

        /// <summary>
        /// Method removes all the datapoints from the every clusters in clusterlist.
        /// </summary>
        public void EmptyClusters()
        {
            foreach (Cluster cluster in clusterList)
            {
                cluster.SetDataList(new List<DataPoint>());//Empty list;
            }
        }

        /// <summary>
        /// Returns the list of clusters bestClusterList.
        /// </summary>
        /// <returns></returns>
        public List<Cluster> GetBestClusters()
        {
            return bestClusterList;
        }

        /// <summary>
        /// For each cluster check is their centers have changed.
        /// </summary>
        public void IsClusterCenterChanged()
        {
            foreach (Cluster cluster in clusterList)
            {
                if (cluster.GetCentroidIsChangedFlag() != false)
                {
                    convergence = 2;
                    return;
                }

            }
            convergence--; //Should only be reach if all the previous result return 2;
        }

        /// <summary>
        /// Method return the total Kmean cost every clusters in clusterList
        /// </summary>
        /// <returns></returns>
        public float GetKMeanCost()
        {
            float newKmean = 0;
            foreach (Cluster cluster in clusterList)
            {
                foreach (DataPoint datapoint in cluster.GetDataPoints())
                {
                    newKmean += (datapoint.GetDistanceDataPoint(cluster.GetCentroidPoint().GetValues()));
                }
            }
            return newKmean;
        }

        /// <summary>
        /// Method returns the best kMean currently recorded.
        /// </summary>
        /// <returns></returns>
        public float GetBestKMeanCost()
        {
            return kMean;
        }

        /// <summary>
        /// Sets the k random points from datapoints as centers
        /// </summary>
        public void SetKCenter()
        {
            clusterList = new List<Cluster>();
            Random random = new Random();
            for (int i = 0; i < kClusters; i++)
            {
                int rand = random.Next(0, dataList.Count());
                Cluster tempCluster = new Cluster();
                tempCluster.SetInitCentroidPoint(dataList[rand]);
                clusterList.Add(tempCluster);
            }
        }

        /// <summary>
        /// Assigns each datapoints to its closest cluster given the cluster center
        /// </summary>
        public void SetPointsToCluster()
        {
            //For eachDataPoints calculate the closest cluster center
            foreach (DataPoint datapoint in dataList)
            {
                int loopNum = 0;
                float distance = -1f;
                int clusterID = -1;
                foreach (Cluster cluster in clusterList)
                {
                    float tempDistance = datapoint.GetDistanceDataPoint(cluster.GetCentroidPoint().GetValues());
                    if (tempDistance < distance || distance == -1f)
                    {
                        clusterID = loopNum;
                        distance = tempDistance;
                    }
                    loopNum++;
                }
                clusterList[clusterID].AddDataPoint(datapoint);

            }
        }

        /// <summary>
        /// Return a representation of the cluster in a string format.
        /// </summary>
        /// <returns></returns>
        public string ClustersToString()
        {
            string toString = "";
            foreach (Cluster cluster in bestClusterList)
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

        /// <summary>
        /// Returns a string representation of each datapoints group in every cluster.
        /// </summary>
        /// <returns></returns>
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
                    toString += (test + "--Point Count: " + points.Count() + "\n");
                }
                toString += "\n";
            }
            return toString;
        }

    }  
}
