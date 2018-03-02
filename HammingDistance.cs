using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster_Algorithm
{
    public class HammingDistance
    {
        private List<Cluster> outputClusterList;
        private List<Cluster> targetClusterList;
        private int nPoints;

        /// <summary>
        /// Initializes Hamming distance with the tempOutputClisterList
        /// </summary>
        /// <param name="tempOuputClusterList"></param>
        public HammingDistance(List<Cluster> tempOuputClusterList)
        {
            outputClusterList = new List<Cluster>(tempOuputClusterList);
            targetClusterList = new List<Cluster>();
        }

        /// <summary>
        /// Method returns a string representation of the clusters groups.
        /// </summary>
        /// <returns></returns>
        public string ClusterGroupToString()
        {
            string toString = "";
            foreach (Cluster cluster in targetClusterList)
            {
                toString += "Cluster: \n";
                IEnumerable<IGrouping<string, DataPoint>> query = cluster.GetDataPoints().GroupBy(data => data.GetLabel());
                foreach (IGrouping<string, DataPoint> points in query)
                {
                    string test = points.Key;
                    toString += ("Label: " + test + " - Amount: " + points.Count() + "\n");
                }
                toString += "\n";
            }
            return toString;
        }

        /// <summary>
        /// Sets the cluster on the targetClusterList
        /// </summary>
        public void SetTargetClusterList(int k,List<DataPoint> newDataList)
        {
            targetClusterList = new List<Cluster>();
            nPoints = newDataList.Count;
            List<DataPoint> dataList = new List<DataPoint>(newDataList);

            //Group the labels together
            IEnumerable<IGrouping<string,DataPoint>> query = dataList.GroupBy(data => data.GetLabel());
            foreach(IGrouping<string,DataPoint> points in query){
                //Console.WriteLine("Key is " + points.Key);
                Cluster tempCluster = new Cluster();
                foreach (DataPoint p in points)
                {
                    tempCluster.AddDataPoint(p); //Add datapoint to cluster

                }
                targetClusterList.Add(tempCluster);//Add cluster to cluster list
            }
        }

        /// <summary>
        /// Sets the cluster on the targetClusterList
        /// </summary>
        public void SetTargetClusterListNoOutliers(int k, List<DataPoint> newDataList, List<DataPoint> outliers)
        {
            List<DataPoint> dataList = new List<DataPoint>();
            //Removes outliers
            foreach (DataPoint dataPoint in newDataList)
            {
                bool outlierFlag = false;
                foreach (DataPoint tempPoint in outliers)
                {
                    if(tempPoint.GetID() == dataPoint.GetID())
                    {
                        outlierFlag = true; 
                    }
                }
                if(outlierFlag == false) { 
                    dataList.Add(dataPoint);
                }
            }
            //Console.WriteLine(dataList.Count);
            nPoints = dataList.Count;
            //Group the labels together
            IEnumerable<IGrouping<string, DataPoint>> query = dataList.GroupBy(data => data.GetLabel());
            foreach (IGrouping<string, DataPoint> points in query)
            {
                //Console.WriteLine("Key is " + points.Key);
                Cluster tempCluster = new Cluster();
                foreach (DataPoint p in points)
                {
                    tempCluster.AddDataPoint(p); //Add datapoint to cluster

                }
                targetClusterList.Add(tempCluster);//Add cluster to cluster list
            }
        }

        /// <summary>
        /// Gets the HammingDistance
        /// </summary>
        /// <returns></returns>
        public float GetHammingDistance()
        {
            //Consider Two clusterings C and C' of the same data set which has n points

            //---------------------------------//
            {//Let a be the nber of edges that are in cluster in C and between clusters in C'
            /*First step is to find all the edges that are in cluster in C and have a list of it.
             *Second step is to compare those edges to the same edges in C' and see if they are in between clusters and not in clusters instead
             *Third step is to save that value into variable a
             * 
             */

            //For each Cluster in C (outputClusterList)
            //Create Edge Pairs with every Datapoints in cluster in sub C
            //For each edge pairs go through all the clusters in C'
            //If only one edge is present in a cluster increase a by 1
            //If none of the edges are present in a cluster move to next cluster.
            //If both edges are found in the same cluster move to next edge pair.
        }
            int a = 0;
            foreach (Cluster cluster in outputClusterList)
            {
                cluster.CreateDataPointPairs();
                foreach (DataPointPair pair in cluster.GetDataPairs()) {
                    int id1 = pair.idOne;
                    int id2 = pair.idTwo;
                    foreach (Cluster clusterPrime in targetClusterList)
                    {
                        int edgeVal = clusterPrime.GetPairs(id1, id2);
                        if (edgeVal == 2)
                        {
                            break;
                        }
                        else if (edgeVal == 1)
                        {
                            a++; //An in-cluser edge in C is a between-cluster in C'
                            break;
                        }
                        else
                        {
                            //Do nothing go to next cluster
                        }
                    }
                }
            }

            //---------------------------------//
            {  /*
             * Let b be the number of edges that are in cluster in C' and between cluster in C
             * First step is to find all is to find all the edges that are in cluster in C' and have a list of it
             * Second is to compare those edges to the same edges in C and see if that are in between cluster and not in
             * Third step is to save value in variable b
             */

            //For each Cluster in C' (tempTargetClusterList)
            //Create Edge Pairs with every Datapoints in cluster in sub C'
            //For each edge pairs go through all the clusters in C
            //If only one edge is present in a cluster increase b by 1
            //If none of the edges are present in a cluster move to next cluster.
            //If both edges are found in the same cluster move to next edge pair.
        }

            int b = 0;
            foreach (Cluster clusterPrime in targetClusterList)
            {
                clusterPrime.CreateDataPointPairs();
                foreach (DataPointPair pair in clusterPrime.GetDataPairs())
                {
                    int id1 = pair.idOne;
                    int id2 = pair.idTwo;
                    foreach (Cluster cluster in outputClusterList)
                    {
                        int edgeVal = cluster.GetPairs(id1, id2);
                        if (edgeVal == 2)
                        {
                            break;
                        }
                        else if (edgeVal == 1)
                        {
                            b++; //An in-cluser edge in C is a between-cluster in C'
                            break;
                        }
                        else
                        {
                            //Do nothing go to next cluster
                        }
                    }
                }
            }

            //----------------------/
            //(a+b) / (n!/2!(n-2)!)
            float hammingDistance = (a + b) / (GetBinCoeff(nPoints, 2));

            return hammingDistance;
        }

        /// <summary>
        /// Returns TargetCluster list.
        /// </summary>
        /// <returns></returns>
        public List<Cluster> GetTargetClusterList()
        {
            return targetClusterList;
        }

        /// <summary>
        /// Method by Mark Dominus
        /// // This function gets the total number of unique combinations based upon N and K.
        /// N is the total number of items.
        /// K is the size of the group.
        /// Total number of unique combinations = N! / ( K! (N - K)! ).
        /// This function is less efficient, but is more likely to not overflow when N and K are large.
        /// Taken from:  http://blog.plover.com/math/choose.html
        /// </summary>
        /// <param name="N"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public float GetBinCoeff(float N, float K)
        {

            float r = 1;
            float d;
            if (K > N) return 0;
            for (d = 1; d <= K; d++)
            {
                r *= N--;
                r /= d;
            }
            return r;
        }
    }
}
