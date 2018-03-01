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
        /// Runs Lloyd's Method
        /// </summary>
        public void Run()
        {
            //Run many times 100 times maybes and select the one with the lowest k-mean cost is selected
            //Pick k random points (call them centers)
            //Until convergence
            //Assign each point to its closest center
            //Compute the mean of each cluster
            //Means are the new centers of clusters
            //Algorithm converges if the clusters dont change in two consecuitve iterations.

            //K-mean objective cost

            for (int i = 0; i < 100; i++)
            {
                System.Threading.Thread.Sleep(50);
                convergence = 2;
                SetKCenter();
                clusterList[0].GetCentroidPoint();
                while (convergence != 0)
                {
                    EmptyClusters();
                    SetPointsToCluster();
                    foreach (Cluster cluster in clusterList)
                    {

                        cluster.SetCentroidPoint();
                    }
                    IsClusterCenterChanged();
                }
                float tempKmean = GetKMeanCost();
                //Console.WriteLine("K Mean: " + tempKmean);
                if (kMean == -1 || tempKmean <kMean)
                {
                    Console.WriteLine("New Lowest K Mean: " + tempKmean);
                    //Console.WriteLine(clusterList[0].GetCentroidPoint());
                    //Console.WriteLine(clusterList[1].GetCentroidPoint());
                    kMean = tempKmean;
                    bestClusterList = new List<Cluster>(clusterList);
                }       
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

        public void EmptyClusters()
        {
            foreach(Cluster cluster in clusterList)
            {
                cluster.SetDataList(new List<DataPoint>());//Empty list;
            }
        }

        /// <summary>
        /// For each cluster check is their centers have changed.
        /// </summary>
        public void IsClusterCenterChanged()
        {
            
            foreach(Cluster cluster in clusterList)
            {
                //Console.WriteLine("Convergence Status: " + cluster.GetCentroidIsChangedFlag());
                if (cluster.GetCentroidIsChangedFlag() != false)
                {
                    convergence = 2;
                    return;
                }

            }
            convergence--; //Should only be reach if all the previous result return 2;
        }

        /// <summary>
        /// Returns the list of clusters clusterlist.
        /// </summary>
        /// <returns></returns>
        public List<Cluster> GetClusters()
        {
            return bestClusterList;
        }

        public float GetKMeanCost()
        {
             /*float newKMean = 0;
             foreach(Cluster cluster in clusterList)
             {
                 float tempKmean = cluster.GetAverageDistancePointstoCenter();
                 newKMean += tempKmean;
             }
             newKMean = newKMean / clusterList.Count;
             return newKMean;*/

            float newKmean = 0;
            foreach(Cluster cluster in clusterList)
            {
                foreach(DataPoint datapoint in cluster.GetDataPoints())
                {
                    newKmean += (datapoint.GetDistanceDataPoint(cluster.GetCentroidPoint().GetValues()));
                }
            }

            return newKmean;
        } 

        /// <summary>
        /// Sets the k random points from datapoints as centers
        /// </summary>
        public void SetKCenter()
        {
            clusterList = new List<Cluster>();
            Random random = new Random();
            for(int i = 0; i < kClusters; i++)
            {
                int rand = random.Next(0, dataList.Count());
                //Console.WriteLine("Random Center:" + dataList[rand].ToStringValues());
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
            foreach(DataPoint datapoint in dataList)
            {
                int loopNum = 0;
                float distance = -1f;
                int clusterID = -1;
                foreach(Cluster cluster in clusterList)
                {
                    float tempDistance = datapoint.GetDistanceDataPoint(cluster.GetCentroidPoint().GetValues());
                    if(tempDistance < distance || distance == -1f)
                    {
                        clusterID = loopNum;
                        distance = tempDistance;
                    }
                    loopNum++;
                }
                clusterList[clusterID].AddDataPoint(datapoint);
                //Console.WriteLine("Cluster ID " + clusterID);

            }
            //Console.ReadLine();
        }
    }  
}
