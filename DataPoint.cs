using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster_Algorithm
{
    public class DataPoint
    {
        private string[] attributesName;
        private float[] values;
        private string label;

        /// <summary>
        /// Initliazes a newly created DataPoint by assigning the size of the two arrays with Array Size
        /// </summary>
        /// <param name="arraySize"></param>
        public DataPoint(int arraySize)
        {
            attributesName = new string[arraySize];
            values = new float[arraySize-1]; //Attributes size - 1 represent the list of values.
        }

        /// <summary>
        /// Initializes a newly created Datapoint by assinging a new list of float.
        /// </summary>
        /// <param name="arrayData"></param>
        public DataPoint(float[] arrayData)
        {
            attributesName = new string[arrayData.Count()+1]; //Attributes size + 1 represent the list of values and label
            values = new float[arrayData.Count()];
            SetValues(arrayData);
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
        /// Get the distance between two points.
        /// </summary>
        /// <param name="pointValues"></param>
        /// <returns></returns>
        public float GetDistanceDataPoint(float[] pointValues)
        {
            float distance = 0;
            for(int i = 0; i < values.Count(); i++)
            {
                distance += ((values[i] - pointValues[i]) * (values[i] - pointValues[i]));
            }
            distance = Convert.ToSingle(Math.Sqrt(distance));
            return distance;
        }

        ///----------------------ToString Methods-----------------------------//

        /// <summary>
        /// Return a string holding the values in values and the label.
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
