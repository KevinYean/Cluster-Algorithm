using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cluster_Algorithm;
using System.Collections.Generic;

namespace TestCases
{
    [TestClass]
    public class LinkageTest
    {
        [TestMethod]
        public void CreateClustersTest1()
        {
            Start test = new Start(@"..\..\..\Data\Sample1D.csv");
            List<DataPoint> temp = test.GetDataPoints();
            Linkage link = new Linkage(10, temp);
            link.CreateClusters();
            int num = link.GetClustersCount();
            Assert.AreEqual(num, 6);
        }

        [TestMethod]
        public void ClusterPairsTest1()
        {
            Start test = new Start(@"..\..\..\Data\Sample1D.csv");
            List<DataPoint> temp = test.GetDataPoints();
            Linkage link = new Linkage(10, temp);
            link.CreateClusters();
            link.CreateClusterPairs();
            int num = link.GetClusterPairsCount();
            Assert.AreEqual(num, 15);
        }

        [TestMethod]
        public void ClusterPairsTest2()
        {
            Start test = new Start(@"..\..\..\Data\DistanceSample1D.csv");
            List<DataPoint> temp = test.GetDataPoints();
            Linkage link = new Linkage(10, temp);
            link.CreateClusters();
            link.CreateClusterPairs();
            int num = link.GetClusterPairsCount();
            Assert.AreEqual(num, 6);
        }

        [TestMethod]
        public void ClusterPairsTest3()
        {
            Start test = new Start(@"..\..\..\Data\Sample01.csv");
            List<DataPoint> temp = test.GetDataPoints();
            Linkage link = new Linkage(10, temp);
            link.CreateClusters();
            link.CreateClusterPairs();
            int num = link.GetClusterPairsCount();
            Assert.AreEqual(num, 105);
        }

        [TestMethod]
        public void ClusterPairsTest4()
        {
            Start test = new Start(@"..\..\..\Data\IrisData.csv");
            List<DataPoint> temp = test.GetDataPoints();
            Linkage link = new Linkage(10, temp);
            link.CreateClusters();
            link.CreateClusterPairs();
            int num = link.GetClusterPairsCount();
            Assert.AreEqual(num, 11175);
        }
    }

}