using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cluster_Algorithm;
using System.Collections.Generic;

namespace TestCases
{
    [TestClass]
    public class LLoydTest
    {

        [TestMethod]
        public void KMeanTest1()
        {
            Start test = new Start(@"..\..\..\Data\DistanceSample1DLloyd.csv");
            List<DataPoint> temp = test.GetDataPoints();
            Lloyds link = new Lloyds(2, temp);
            link.Run(100);
            Assert.AreEqual(link.GetBestKMeanCost(),6.4f);
        }




    }

}
