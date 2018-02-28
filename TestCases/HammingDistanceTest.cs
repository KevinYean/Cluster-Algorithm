using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cluster_Algorithm;
using System.Collections.Generic;

namespace TestCases
{
    [TestClass]
    public class HammingDistanceTest
    {
        [TestMethod]
        public void ClusterGroupTest1()
        {
            Start test = new Start(@"..\..\..\Data\IrisData.csv");
            List<DataPoint> temp = test.GetDataPoints();
            HammingDistance link = new HammingDistance(new List<Cluster>());
            link.SetTargetClusterList(3,temp);
            int dataNum = link.GetTargetClusterList()[0].GetDataPoints().Count;
            Assert.AreEqual(dataNum, 50);
        }

        [TestMethod]
        public void ClusterGroupTest2()
        {
            Start test = new Start(@"..\..\..\Data\IrisData.csv");
            List<DataPoint> temp = test.GetDataPoints();
            HammingDistance link = new HammingDistance(new List<Cluster>());
            link.SetTargetClusterList(3, temp);
            int dataNum = link.GetTargetClusterList()[1].GetDataPoints().Count;
            Assert.AreEqual(dataNum, 50);
        }

        [TestMethod]
        public void ClusterGroupTest3()
        {
            Start test = new Start(@"..\..\..\Data\IrisData.csv");
            List<DataPoint> temp = test.GetDataPoints();
            HammingDistance link = new HammingDistance(new List<Cluster>());
            link.SetTargetClusterList(3, temp);
            int dataNum = link.GetTargetClusterList()[2].GetDataPoints().Count;
            Assert.AreEqual(dataNum, 50);
        }

        [TestMethod]
        public void ClusterGroupTest4()
        {
            Start test = new Start(@"..\..\..\Data\KnowledgeData.csv");
            List<DataPoint> temp = test.GetDataPoints();
            HammingDistance link = new HammingDistance(new List<Cluster>());
            link.SetTargetClusterList(4, temp);
            int dataNum = link.GetTargetClusterList()[0].GetDataPoints().Count;
            Assert.AreEqual(dataNum, 24);
        }

        [TestMethod]
        public void ClusterGroupTest5()
        {
            Start test = new Start(@"..\..\..\Data\KnowledgeData.csv");
            List<DataPoint> temp = test.GetDataPoints();
            HammingDistance link = new HammingDistance(new List<Cluster>());
            link.SetTargetClusterList(4, temp);
            int dataNum = link.GetTargetClusterList()[1].GetDataPoints().Count;
            Assert.AreEqual(dataNum, 63);
        }

        [TestMethod]
        public void ClusterGroupTest6()
        {
            Start test = new Start(@"..\..\..\Data\KnowledgeData.csv");
            List<DataPoint> temp = test.GetDataPoints();
            HammingDistance link = new HammingDistance(new List<Cluster>());
            link.SetTargetClusterList(4, temp);
            int dataNum = link.GetTargetClusterList()[2].GetDataPoints().Count;
            Assert.AreEqual(dataNum, 83);
        }

        [TestMethod]
        public void ClusterGroupTest7()
        {
            Start test = new Start(@"..\..\..\Data\KnowledgeData.csv");
            List<DataPoint> temp = test.GetDataPoints();
            HammingDistance link = new HammingDistance(new List<Cluster>());
            link.SetTargetClusterList(4, temp);
            int dataNum = link.GetTargetClusterList()[3].GetDataPoints().Count;
            Assert.AreEqual(dataNum, 88);
        }

        [TestMethod]
        public void GetBinCoeffTest1()
        {
            Start test = new Start(@"..\..\..\Data\KnowledgeData.csv");
            List<DataPoint> temp = test.GetDataPoints();
            HammingDistance link = new HammingDistance(new List<Cluster>());
            float on = link.GetBinCoeff(5, 2);
            Assert.AreEqual(on, 10);
        }

        [TestMethod]
        public void GetBinCoeffTest2()
        {
            Start test = new Start(@"..\..\..\Data\KnowledgeData.csv");
            List<DataPoint> temp = test.GetDataPoints();
            HammingDistance link = new HammingDistance(new List<Cluster>());
            float on = link.GetBinCoeff(10, 2);
            Assert.AreEqual(on, 45);
        }
    }

}
