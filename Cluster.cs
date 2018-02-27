using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster_Algorithm
{
    /// <summary>
    /// A simple Class that holds ClusterPairs and their distances from each other.
    /// </summary>
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
        private List<DataPoint> dataList; //List of Data Points
        private List<DataPointPair> dataPairList; //List of DataPairs
        private DataPoint centroidPoint;

        /// <summary>
        /// Initiliazes a constructor which creates a new list of dataPoints.
        /// </summary>
        public Cluster()
        {
            dataList = new List<DataPoint>();
        }

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
        /// Create all DataPointPairs
        /// </summary>
        public void CreateDataPointPairs()
        {
            dataPairList = new List<DataPointPair>(); //Reset everytime.
            //n(n - 1) / 2
            for (int i = 0; i < dataList.Count; i++)
            {
                for (int y = i + 1; y < dataList.Count; y++)
                {
                    DataPointPair tempPointPair = new DataPointPair();
                    tempPointPair.pointOne = i;
                    tempPointPair.pointTwo = y;
                    dataPairList.Add(tempPointPair);
                }
            }
        }

        /// <summary>
        /// Set the distance for each dataPairs
        /// </summary>
        /// <returns></returns>
        public void SetDataPairsDistances()
        {
            //Go through every distance pairs
            for(int x = 0; x < dataPairList.Count; x++)
            {
                int pointOne = dataPairList[x].pointOne;
                int pointTwo = dataPairList[x].pointTwo;
                //Calculate distance between the two points in the pairs.
                float tempDistance = dataList[pointOne].GetDistanceDataPoint(dataList[pointTwo].GetValues());
                dataPairList[x].distance = tempDistance; //Set the distance
            }
        }

        /// <summary>
        /// Returns ClusterPairs as a string.
        /// </summary>
        /// <returns></returns>
        public string DataPairsToString()
        {
            string toString = "";
            foreach (DataPointPair pair in dataPairList)
            {
                toString += "Point Pair: [" + pair.pointOne + "][" + pair.pointTwo + "], Distance: " + pair.distance + "\n";
            }
            return toString;
        }

        /// <summary>
        /// Returns the count of of Datapoint pairs
        /// </summary>
        /// <returns></returns>
        public float GetDataPairsCount()
        {
            return dataList.Count;
        }

        /// <summary>
        /// Return the average distance of all the distances between data pairs.
        /// </summary>
        /// <returns></returns>
        public float GetClusterAverageDistance()
        {
            float avgDistance = 0;
            //Go through every data pairs
            for(int i = 0; i < dataPairList.Count; i++)
            {
                avgDistance += dataPairList[i].distance;
            }
            avgDistance = avgDistance / dataList.Count;
            return avgDistance;
        }

        /// <summary>
        /// Set the centroid of the points in the cluster.
        /// </summary>
        public void SetCentroidPoint()
        {
            List<float> values = new List<float>();
            for(int i = 0; i < dataList[0].GetValuesLength(); i++)
            {
                float tempVal = 0;
                for(int x = 0; x < dataList.Count; x++)
                {
                    tempVal += dataList[x].GetValues()[i];
                }
                tempVal = tempVal / dataList.Count;
                values.Add(tempVal);
            }

            centroidPoint = new DataPoint(values.ToArray());
        }

        public DataPoint GetCentroidPoint()
        {
            return centroidPoint;
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
                dataList.Add(otherCluster.GetDataPoints()[i]);
            }
        }
    }
}
