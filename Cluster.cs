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
        private DataPoint centroidPoint; //Center
        private bool centroidIsChangedFlag;

        /// <summary>
        /// Initiliazes a constructor which creates a new list of dataPoints.
        /// </summary>
        public Cluster()
        {
            dataList = new List<DataPoint>();
            centroidIsChangedFlag = false;
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
            centroidIsChangedFlag = false;
        }

        /// <summary>
        /// Method sets dataList with a brand new list of Datapoints.
        /// </summary>
        /// <param name="newDataList"></param>
        public void SetDataList(List<DataPoint> newDataList)
        {
            dataList = new List<DataPoint>(newDataList);
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
                    tempPointPair.idOne = dataList[i].GetID();
                    tempPointPair.pointTwo = y;
                    tempPointPair.idTwo = dataList[y].GetID();
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
            float avgDistance = 0f;
            //Go through every data pairs
            for(int i = 0; i < dataPairList.Count; i++)
            {
                avgDistance += dataPairList[i].distance;
            }
            avgDistance = avgDistance / dataList.Count;
            return avgDistance;
        }

        /// <summary>
        /// Set the centroid of the cluster given the the points in the cluster.
        /// </summary>
        public void SetCentroidPoint()
        {
            List<float> values = new List<float>();
            if (dataList.Count != 0) // Awful way to prevent errors when the Cluster has zero points
            {
                for (int i = 0; i < dataList[0].GetValuesLength(); i++)
                {
                    float tempVal = 0f;
                    for (int x = 0; x < dataList.Count; x++)
                    {
                        tempVal += dataList[x].GetValues()[i];
                    }
                    tempVal = tempVal / dataList.Count;
                    values.Add(tempVal);
                }
                DataPoint tempPoint = new DataPoint(values.ToArray(), 1);

                if (centroidPoint.GetValues().SequenceEqual(tempPoint.GetValues()))
                {
                    centroidIsChangedFlag = false;
                }
                else
                {
                    centroidIsChangedFlag = true;
                }
                centroidPoint = tempPoint;
            }
        }

        /// <summary>
        /// Method Return the boolean flag;
        /// </summary>
        /// <returns></returns>
        public bool GetCentroidIsChangedFlag()
        {
            return centroidIsChangedFlag;
        }

        /// <summary>
        /// Method sets the new Centroid point of a cluster
        /// </summary>
        /// <param name="newCenter"></param>
        public void SetInitCentroidPoint(DataPoint newCenter)
        {
            centroidPoint = newCenter;//might have reference problem later down the line
        }

        /// <summary>
        /// Method returns the avg distance of all points in the cluster to the given center
        /// </summary>
        public float GetAverageDistancePointstoCenter()
        {
            float avg = 0;
            foreach(DataPoint datapoint in dataList)
            {
                float distance = datapoint.GetDistanceDataPoint(centroidPoint.GetValues());
                avg += distance;
            }
            avg = avg / dataList.Count;
            return avg;
        }

        /// <summary>
        /// Method return the Centroidpoint
        /// </summary>
        /// <returns></returns>
        public DataPoint GetCentroidPoint()
        {
            return centroidPoint;
        }
        
        /// <summary>
        /// Add a new Datapoint to the list of data points.
        /// </summary>
        /// <param name="newDataPoint"></param>
        public void AddDataPoint(DataPoint newDataPoint)
        {
            dataList.Add(newDataPoint);
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
        /// Method returns the DataPairs
        /// </summary>
        /// <returns></returns>
        public List<DataPointPair> GetDataPairs()
        {
            return dataPairList;
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

        /// <summary>
        /// Method is used to see if the edge pair ID provided exist in this cluster
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        public int GetPairs(int id1,int id2)
        {
            int edgeVal = 0;
            //Go through all the datapoints in the cluster
            foreach(DataPoint dataPoint in dataList)
            {
                //Check if they exist
                if(dataPoint.GetID() == id1 || dataPoint.GetID() == id2)
                {
                    edgeVal++;
                }
            }
            return edgeVal;
        }
    }
}
