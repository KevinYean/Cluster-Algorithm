using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cluster_Algorithm;
using System.Collections.Generic;

namespace TestCases
{
    [TestClass]
    public class AverageLinkageTest
    {
        [TestMethod]
        public void InheritanceAverageTest1()
        {
            SingleLinkage singleLinkage = new SingleLinkage();
            int inheritance = singleLinkage.TestInheritance();
            Assert.AreEqual(inheritance, -1);
        }

        [TestMethod]
        public void AverageLinkageTest1()
        {
            Start test = new Start(@"..\..\..\Data\DistanceSample1DAverage.csv");
            List<DataPoint> temp = test.GetDataPoints();
            AverageLinkage link = new AverageLinkage(2, temp);
            link.Run();
            int dataNum = link.GetClusters()[0].GetDataPoints().Count;
            Assert.AreEqual(dataNum, 2);
        }

        [TestMethod]
        public void AverageLinkageTest2()
        {
            Start test = new Start(@"..\..\..\Data\DistanceSample2DAverage.csv");
            List<DataPoint> temp = test.GetDataPoints();
            AverageLinkage link = new AverageLinkage(2, temp);
            link.Run();
            int dataNum = link.GetClusters()[0].GetDataPoints().Count;
            Assert.AreEqual(dataNum, 5);
        }


    }

}
