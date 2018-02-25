using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster_Algorithm
{
    public class DataPoint
    {
        int oneDimensionVar; //Test Variable
        string oneDimensionAttri; //Test Variable

        private string[] attributesName;
        private float[] values;
        private string label;

        /// <summary>
        /// Initializes a newly created DataPoint with just one variable.
        /// </summary>
        /// <param name="newOneDimensionVar"></param>
        /// <param name="newOneDimensionAttri"></param>
        public DataPoint(int newOneDimensionVar,string newOneDimensionAttri)
        {
            oneDimensionVar = newOneDimensionVar;
            oneDimensionAttri = newOneDimensionAttri;
        }

        /// <summary>
        /// Initliazes a newly created DataPoint by assigning the size of the two arrays with Array Size
        /// </summary>
        /// <param name="arraySize"></param>
        public DataPoint(int arraySize)
        {
            attributesName = new string[arraySize];
            values = new float[arraySize-1];
        }

        /// <summary>
        /// Sets values in the array values.
        /// </summary>
        /// <param name="arrayData"></param>
        public void SetData(float[] arrayData)
        {
            for(int i = 0; i < arrayData.Count(); i++)
            {
                values[i] = arrayData[i];
            }
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
        public int GetValuesSize()
        {
            return values.Length;
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
