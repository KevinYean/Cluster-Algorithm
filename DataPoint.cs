using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster_Algorithm
{
    /// <summary>
    /// A simple Class that holds DataPointPairs and their distances from each other.
    /// </summary>
    public class DataPointPair
    {
        public int pointOne;
        public int idOne;
        public int pointTwo;
        public int idTwo;
        public float distance;

    }

    public class DataPoint
    {
        private string[] attributesName;
        private float[] values;
        private string label;
        private int id;
        private int clusterID;
        private bool corePoint;

        /// <summary>
        /// Initliazes a newly created DataPoint by assigning the size of the two arrays with Array Size
        /// </summary>
        /// <param name="arraySize"></param>
        public DataPoint(int arraySize,int newID)
        {
            id = newID;
            attributesName = new string[arraySize];
            values = new float[arraySize-1]; //Attributes size - 1 represent the list of values.
            corePoint = false;
        }

        /// <summary>
        /// Initializes a newly created Datapoint by assinging a new list of float.
        /// </summary>
        /// <param name="arrayData"></param>
        public DataPoint(float[] arrayData,int newID)
        {
            id = newID;
            attributesName = new string[arrayData.Count()+1]; //Attributes size + 1 represent the list of values and label
            values = new float[arrayData.Count()];
            SetValues(arrayData);
            corePoint = false;
        }

        /// <summary>
        /// Returns the ID of the dataPoint
        /// </summary>
        /// <returns></returns>
        public int GetID()
        {
            return id;
        }

        /// <summary>
        /// Sets values in the array values.
        /// </summary>
        /// <param name="arrayData"></param>
        public void SetValues(float[] arrayData)
        {
            for(int i = 0; i < arrayData.Count(); i++)
            {
                values[i] = arrayData[i];
            }
        }

        /// <summary>
        /// Returns the values array
        /// </summary>
        /// <returns></returns>
        public float[] GetValues()
        {
            return values;
        }

        /// <summary>
        /// Returns the length of the array values.
        /// </summary>
        /// <returns></returns>
        public int GetValuesLength()
        {
            return values.Length;
        }

        /// <summary>
        /// Sets a new label to the label string.
        /// </summary>
        /// <param name="newLabel"></param>
        public void SetLabel(string newLabel)
        {
            label = newLabel;
        }

        /// <summary>
        /// Return label value.
        /// </summary>
        /// <returns></returns>
        public string GetLabel()
        {
            return label;
        }

        /// <summary>
        /// Method set core points flag value
        /// </summary>
        /// <param name=""></param>
        public void SetCorePoint(bool newBool)
        {
            corePoint = newBool;
        }

        /// <summary>
        /// Method returns core point
        /// </summary>
        /// <returns></returns>
        public bool GetCorePoint()
        {
            return corePoint;
        }

        /// <summary>
        /// Method sets the clusterID
        /// </summary>
        /// <param name="id"></param>
        public void SetClusterID(int id)
        {
            clusterID = id;
        }

        /// <summary>
        /// Method Returns clusterID
        /// </summary>
        /// <returns></returns>
        public int GetClusterID()
        {
            return clusterID;
        }


        /// <summary>
        /// Get the distance between two points.
        /// </summary>
        /// <param name="pointValues"></param>
        /// <returns></returns>
        public float GetDistanceDataPoint(float[] pointValues)
        {
            float distance = 0f;
            for(int i = 0; i < values.Count(); i++)
            {
                distance += ((values[i] - pointValues[i]) * (values[i] - pointValues[i]));
            }
            distance = Convert.ToSingle(Math.Sqrt(distance));
            return distance;
        }

        ///----------------------ToString Methods-----------------------------//

        /// <summary>
        /// Return a string holding the values in values and the label and ID.
        /// </summary>
        /// <returns></returns>
        override public string ToString()
        {
            string toString = "";
            foreach(float val in values)
            {
                toString += val + ",";
            }
            toString += label;
            toString += ",ID: " + id;
            return toString;
        }

        /// <summary>
        /// Returns a string holding the values in values.
        /// </summary>
        /// <returns></returns>
        public string ToStringValues()
        {
            string toString = "";
            foreach (float val in values)
            {
                toString += val + ",";
            }
            return toString;
        }

    }
}
