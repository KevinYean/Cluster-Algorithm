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
            FileReader fileReader = new FileReader();
            fileReader.ReadCSVFile(@"..\..\..\Sample1D.csv");
            fileReader.ConvertDataString();
            List<DataPoint> temp = fileReader.GetDataPoints();
            Linkage link = new Linkage(10, temp);
            link.CreateClusters();
            int num = link.GetClustersCount();
            Assert.AreEqual(num, 9);
        }
    }

}
