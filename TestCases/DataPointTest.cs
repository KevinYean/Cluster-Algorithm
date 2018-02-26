using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cluster_Algorithm;
using System.Collections.Generic;

namespace TestCases
{
    [TestClass]
    public class DataPointTest
    {
        [TestMethod]
        public void GetDistanceDataPoint1()
        {
            float[] array1 = new float[] { 1 };
            DataPoint data1 = new DataPoint(2);
            data1.SetValues(array1);

            float[] array2 = new float[] { 4 };
            DataPoint data2 = new DataPoint(2);
            data2.SetValues(array2);

            float[] array = data2.GetValues();
            float distance = data1.GetDistanceDataPoint(array);

            Assert.AreEqual(distance, 3);
        }

        [TestMethod]
        public void GetDistanceDataPoint2()
        {
            float[] array1 = new float[] { 2 };
            DataPoint data1 = new DataPoint(2);
            data1.SetValues(array1);

            float[] array2 = new float[] { 8 };
            DataPoint data2 = new DataPoint(2);
            data2.SetValues(array2);

            float[] array = data2.GetValues();
            float distance = data1.GetDistanceDataPoint(array);

            Assert.AreEqual(distance, 6);
        }

        [TestMethod]
        public void GetDistanceDataPoint3()
        {
            float[] array1 = new float[] { -4 };
            DataPoint data1 = new DataPoint(2);
            data1.SetValues(array1);

            float[] array2 = new float[] { 10 };
            DataPoint data2 = new DataPoint(2);
            data2.SetValues(array2);

            float[] array = data2.GetValues();
            float distance = data1.GetDistanceDataPoint(array);

            Assert.AreEqual(distance, 14);
        }

        [TestMethod]
        public void GetDistanceDataPoint4()
        {
            float[] array1 = new float[] { 5,1 };
            DataPoint data1 = new DataPoint(3);
            data1.SetValues(array1);

            float[] array2 = new float[] {1,-2 };
            DataPoint data2 = new DataPoint(3);
            data2.SetValues(array2);

            float[] array = data2.GetValues();
            float distance = data1.GetDistanceDataPoint(array);
            distance = Convert.ToSingle(Math.Round(distance, 2));
            Assert.AreEqual(distance, 5);
        }

        [TestMethod]
        public void GetDistanceDataPoint5()
        {
            float[] array1 = new float[] { 0,0,-1};
            DataPoint data1 = new DataPoint(4);
            data1.SetValues(array1);

            float[] array2 = new float[] { 8, 6, -1 };
            DataPoint data2 = new DataPoint(4);
            data2.SetValues(array2);

            float[] array = data2.GetValues();
            float distance = data1.GetDistanceDataPoint(array);
            distance = Convert.ToSingle(Math.Round(distance, 2));
            Assert.AreEqual(distance, 10);
        }
    }

}
