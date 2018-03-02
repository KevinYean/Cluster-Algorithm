using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*https://en.wikipedia.org/wiki/DBSCAN
 */

namespace Cluster_Algorithm
{
    /// <summary>
    /// 
    /// Recommened minPts > d + 1 // 2*d
    /// </summary>
    public class DBSCAN
    {
        public List<DataPoint> dataList;
        public List<Cluster> clusterList;
        public List<DataPoint> outliers;
        public int count;

        public DBSCAN(List<DataPoint> newDataList)
        {
            dataList = new List<DataPoint>(newDataList);
            clusterList = new List<Cluster>();
            outliers = new List<DataPoint>();
        }

        public void Run(float distance, int minPts)
        {
            /*A point p is a core point if at least minPts points are within distance ε(ε is the maximum radius of the neighborhood from p) of it(including p). Those points are said to be directly reachable from p.
            A point q is directly reachable from p if point q is within distance ε from point p and p must be a core point.
            A point q is reachable from p if there is a path p1, ..., pn with p1 = p and pn = q, where each pi+1 is directly reachable from pi (all the points on the path must be core points, with the possible exception of q).
            All points not reachable from any other point are outliers.

            Now if p is a core point, then it forms a cluster together with all points (core or non-core) that are reachable from it. Each cluster contains at least one core point; non-core points can be part of a cluster, but they form its "edge", since they cannot be used to reach more points.

              */

            //Pseudocode
            //Create a duplicate of the DataPoint list, but make sure to not reference it.

            //Sets every data point to a negative cluster to demonstrate they currenty belong to no one.
            foreach (DataPoint datapoint in dataList)
            {
                datapoint.SetClusterID(-1);
            }

            foreach (DataPoint datapoint in dataList)
            {
                //Console.WriteLine("ID: " + datapoint.GetClusterID());
            }

            int clusterID = -1;
            //Go through everypoint
            foreach(DataPoint datapoint in dataList)
            {
                //Console.WriteLine(datapoint.ToString());
                //Console.WriteLine("ID: " + datapoint.GetClusterID());
                //Skip point if belongs to a cluster already
                if (datapoint.GetClusterID() == -1)
                {
                    List<DataPoint> qPoints = new List<DataPoint>();
                    //Find all points that are within e distance of that point
                    //Console.WriteLine(datapoint.ToString());
                    //Console.WriteLine(datapoint.GetClusterID());

                    foreach (DataPoint data in dataList)
                    {
                        if (datapoint.GetID() != data.GetID())
                        { //Make sure to not count the same point.
                            //Within radius
                            if (datapoint.GetDistanceDataPoint(data.GetValues()) <= distance)
                            {
                                qPoints.Add(data);
                                //Console.WriteLine("Distance " + datapoint.GetDistanceDataPoint(data.GetValues()));
                            }
                        }
                    }
                    // 1 If points has at least minPts within an e distance make it a corepoint and create a new cluster for it            
                    if (qPoints.Count >= minPts)
                    {
                        clusterID += 1;
                        // 2 Label it as core in datapoint
                        datapoint.SetCorePoint(true);
                        datapoint.SetClusterID(clusterID);

                        //Assign all q points to that cluster
                        foreach (DataPoint point in qPoints)
                        {
                            //Console.WriteLine(clusterID);
                            point.SetClusterID(clusterID); //Make that point belong to cluster
                        }
                        //Add it a brandnew cluster
                        Cluster newCluster = new Cluster();
                        newCluster.AddDataPoint(datapoint);

                        //go through everyqpoints as long as it is bigger

                        while (qPoints.Count > 0)
                        {
                            //Console.WriteLine("Q Point list size: " + qPoints.Count);
                            qPoints[0].SetClusterID(clusterID); //Make that point belong to cluster

                            List<DataPoint> tempList = new List<DataPoint>();
                            //3 foreach points it found within the radius
                            foreach (DataPoint data in dataList)
                            {
                                //Make sure to not count the same point.
                                if (qPoints[0].GetID() != data.GetID())
                                {
                                    //Within radius
                                    if (qPoints[0].GetDistanceDataPoint(data.GetValues()) <= distance)
                                    {
                                        tempList.Add(data);
                                    }
                                }
                            }
                            if (tempList.Count >= minPts)
                            {
                                // 2 Label it as core in datapoint
                                qPoints[0].SetCorePoint(true);
                                //Assign all found q points to qPointlist and assign them that cluster if they have not been encountered already
                                foreach (DataPoint data in tempList)
                                {
                                    if (data.GetClusterID() != clusterID)
                                    {
                                        data.SetClusterID(clusterID); //Make that point belong to cluster
                                        qPoints.Add(data);
                                    }
                                }
                                //Add it a brandnew cluster
                                newCluster.AddDataPoint(qPoints[0]);
                            }
                            else //just a q point
                            {
                                //Add it a brandnew cluster
                                newCluster.AddDataPoint(qPoints[0]);
                            }

                            qPoints.RemoveAt(0); //Decrement
                        }

                        clusterList.Add(newCluster);
                    }
                }
            }
                
            foreach(DataPoint dataPoint in dataList)
            {
                if(dataPoint.GetClusterID() == -1)
                {
                    outliers.Add(dataPoint);
                }
            }

        }

        /// <summary>
        /// Method returns a string representation of the clusters groups.
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
                    toString += ("Label: " + test + " - Amount: " + points.Count() + "\n");
                }
                toString += "\n";
            }
            foreach(DataPoint point in dataList)
            {
                if(point.GetClusterID() == -1)
                {
                    count++;
                }
            }
            //toString += "Number of Outliers: \n" + count;
            return toString;
        }
    }
}