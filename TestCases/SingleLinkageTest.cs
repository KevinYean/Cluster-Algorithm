using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cluster_Algorithm;
using System.Collections.Generic;

namespace TestCases
{
    [TestClass]
    public class SingleLinkageTest
    {
        [TestMethod]
        public void InheritanceSingleTest1()
        {
            SingleLinkage singleLinkage = new SingleLinkage();
            int inheritance = singleLinkage.TestInheritance();
            Assert.AreEqual(inheritance, -1);
        }

        [TestMethod]
        public void SingleLinkageCluster1()
        {
            Start test = new Start(@"..\..\..\Data\DistanceSample1D.csv");
            List<DataPoint> temp = test.GetDataPoints();
            SingleLinkage link = new SingleLinkage(2, temp);
            link.Run();
            int dataNum = link.GetClusters()[0].GetDataPoints().Count;
            Assert.AreEqual(dataNum, 3);
        }

        [TestMethod]
        public void SingleLinkageCluster2()
        {
            Start test = new Start(@"..\..\..\Data\DistanceSample1D.csv");
            List<DataPoint> temp = test.GetDataPoints();
            SingleLinkage link = new SingleLinkage(2, temp);
            link.Run();
            int dataNum = link.GetClusters()[1].GetDataPoints().Count;
            Assert.AreEqual(dataNum, 1);
        }

        [TestMethod]
        public void SingleLinkageCluster3()
        {
            Start test = new Start(@"..\..\..\Data\DistanceSample2D.csv");
            List<DataPoint> temp = test.GetDataPoints();
            SingleLinkage link = new SingleLinkage(2, temp);
            link.Run();
            int dataNum = link.GetClusters()[0].GetDataPoints().Count;
            Assert.AreEqual(dataNum, 3);
        }

        [TestMethod]
        public void SingleLinkageCluster4()
        {
            Start test = new Start(@"..\..\..\Data\DistanceSample2D.csv");
            List<DataPoint> temp = test.GetDataPoints();
            SingleLinkage link = new SingleLinkage(2, temp);
            link.Run();
            int dataNum = link.GetClusters()[1].GetDataPoints().Count;
            Assert.AreEqual(dataNum, 5);
        }

        [TestMethod]
        public void SingleLinkageCluster5()
        {
            Start test = new Start(@"..\..\..\Data\DistanceSample3D.csv");
            List<DataPoint> temp = test.GetDataPoints();
            SingleLinkage link = new SingleLinkage(3, temp);
            link.Run();
            int dataNum = link.GetClusters()[1].GetDataPoints().Count;
            Assert.AreEqual(dataNum, 3);
        }

        [TestMethod]
        public void SingleLinkageCluster6()
        {
            Start test = new Start(@"..\..\..\Data\DistanceSample3D.csv");
            List<DataPoint> temp = test.GetDataPoints();
            SingleLinkage link = new SingleLinkage(3, temp);
            link.Run();
            int dataNum = link.GetClusters()[1].GetDataPoints().Count;
            Assert.AreEqual(dataNum, 3);
        }

        [TestMethod]
        public void SingleLinkageCluster7()
        {
            Start test = new Start(@"..\..\..\Data\DistanceSample3D.csv");
            List<DataPoint> temp = test.GetDataPoints();
            SingleLinkage link = new SingleLinkage(3, temp);
            link.Run();
            int dataNum = link.GetClusters()[2].GetDataPoints().Count;
            Assert.AreEqual(dataNum, 1);
        }

        [TestMethod]
        public void SingleLinkageCluster8()
        {
            Start test = new Start(@"..\..\..\Data\DistanceSample1Dx.csv");
            List<DataPoint> temp = test.GetDataPoints();
            SingleLinkage link = new SingleLinkage(2, temp);
            link.Run();
            int dataNum = link.GetClusters()[0].GetDataPoints().Count;
            Assert.AreEqual(dataNum, 3);
        }

    }

}
