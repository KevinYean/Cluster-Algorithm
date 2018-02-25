using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cluster_Algorithm;
using System.Collections.Generic;

namespace TestCases
{
    [TestClass]
    public class StartTest
    {
        [TestMethod]
        public void ConvertDataStringTest1()
        {
            Start test = new Start(@"..\..\..\Data\Sample1D.csv");
            int dataSize = test.GetDataListSize();
            Assert.AreEqual(dataSize, 6);
        }

        [TestMethod]
        public void GetDataPointsTest1()
        {
            Start test = new Start(@"..\..\..\Data\Sample1D.csv");
            List<DataPoint> data = test.GetDataPoints();
            Assert.AreEqual(data.Count, 6);
        }

        [TestMethod]
        public void GetDataPointsTest2()
        {
            Start test = new Start(@"..\..\..\Data\SeedData.csv");
            List<DataPoint> data = test.GetDataPoints();
            Assert.AreEqual(data.Count, 210);
        }

        [TestMethod]
        public void GetDataPointsTest3()
        {
            Start test = new Start(@"..\..\..\Data\IrisData.csv");
            List<DataPoint> data = test.GetDataPoints();
            Assert.AreEqual(data.Count, 150);
        }

        [TestMethod]
        public void GetDataPointsTest4()
        {
            Start test = new Start(@"..\..\..\Data\KnowledgeData.csv");
            List<DataPoint> data = test.GetDataPoints();
            Assert.AreEqual(data.Count, 258);
        }

        [TestMethod]
        public void GetDataPointsTest5()
        {
            Start test = new Start(@"..\..\..\Data\DistanceSample1D.csv");
            List<DataPoint> data = test.GetDataPoints();
            Assert.AreEqual(data.Count, 4);
        }
    }

}
