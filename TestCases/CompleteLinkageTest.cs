using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cluster_Algorithm;
using System.Collections.Generic;

namespace TestCases
{
    [TestClass]
    public class CompleteLinkageTest
    {
        [TestMethod]
        public void InheritanceCompleteTest1()
        {
            SingleLinkage singleLinkage = new SingleLinkage();
            int inheritance = singleLinkage.TestInheritance();
            Assert.AreEqual(inheritance, -1);
        }

        [TestMethod]
        public void CompleteLinkageCluster1()
        {
            Start test = new Start(@"..\..\..\Data\DistanceSample1Dx.csv");
            List<DataPoint> temp = test.GetDataPoints();
            CompleteLinkage link = new CompleteLinkage(2, temp);
            link.Run();
            int dataNum = link.GetClusters()[0].GetDataPoints().Count;
            Assert.AreEqual(dataNum, 2);
        }

        [TestMethod]
        public void CompleteLinkageCluster2()
        {
            Start test = new Start(@"..\..\..\Data\DistanceSample1Dx.csv");
            List<DataPoint> temp = test.GetDataPoints();
            CompleteLinkage link = new CompleteLinkage(2, temp);
            link.Run();
            int dataNum = link.GetClusters()[1].GetDataPoints().Count;
            Assert.AreEqual(dataNum, 2);
        }

        [TestMethod]
        public void CompleteLinkageCluster3()
        {
            Start test = new Start(@"..\..\..\Data\DistanceSample1Dx.csv");
            List<DataPoint> temp = test.GetDataPoints();
            CompleteLinkage link = new CompleteLinkage(2, temp);
            link.Run();
            int dataNum = link.GetClusters()[0].GetDataPoints().Count;
            Assert.AreEqual(dataNum, 2);
        }

        [TestMethod]
        public void CompleteLinkageCluster4()
        {
            Start test = new Start(@"..\..\..\Data\DistanceSample2DComplete.csv");
            List<DataPoint> temp = test.GetDataPoints();
            CompleteLinkage link = new CompleteLinkage(2, temp);
            link.Run();
            int dataNum = link.GetClusters()[1].GetDataPoints().Count;
            Assert.AreEqual(dataNum, 2);
        }
    }

}
