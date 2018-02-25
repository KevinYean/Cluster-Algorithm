using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cluster_Algorithm;
using System.Collections.Generic;

namespace TestCases
{
    [TestClass]
    public class ClusterTest
    {
        [TestMethod]
        public void MergeClusterTest1()
        {
            float[] array1 = new float[] { 0, 0, -1};
            DataPoint data1 = new DataPoint(4);
            data1.SetData(array1);

            float[] array2 = new float[] { 8, 6, -1 };
            DataPoint data2 = new DataPoint(4);
            data2.SetData(array2);

            Cluster cluster1 = new Cluster(data1);
            Cluster cluster2 = new Cluster(data2);

            cluster1.MergeCluster(cluster2);
            int clusterSize = cluster1.GetDataPoints().Count;
            Assert.AreEqual(clusterSize, 2);
        }

        [TestMethod]
        public void MergeClusterTest2()
        {
            float[] array1 = new float[] { 0, 0, -1 };
            DataPoint data1 = new DataPoint(4);
            data1.SetData(array1);

            float[] array2 = new float[] { 8, 6, -1 };
            DataPoint data2 = new DataPoint(4);
            data2.SetData(array2);

            float[] array3 = new float[] { 8, 6, -1 };
            DataPoint data3 = new DataPoint(4);
            data3.SetData(array3);

            Cluster cluster1 = new Cluster(data1);
            Cluster cluster2 = new Cluster(data2);
            Cluster cluster3 = new Cluster(data3);

            cluster1.MergeCluster(cluster2);
            cluster1.MergeCluster(cluster3);
            int clusterSize = cluster1.GetDataPoints().Count;
            Assert.AreEqual(clusterSize, 3);
        }

    }

}
