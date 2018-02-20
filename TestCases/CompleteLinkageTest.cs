using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cluster_Algorithm;

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
    }

}
