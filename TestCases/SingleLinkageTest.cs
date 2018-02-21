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
        public void GetKClustersTest1()
        {
            List<DataPoint> tempList = new List<DataPoint>();
            tempList.Add(new DataPoint(1, "cake"));
            SingleLinkage singleLinkage = new SingleLinkage(10,tempList);
            int clusterSize = singleLinkage.GetK();
            Assert.AreEqual(clusterSize, 10);
        }
    }

}
