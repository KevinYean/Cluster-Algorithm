using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cluster_Algorithm;
using System.Collections.Generic;

namespace TestCases
{
    [TestClass]
    public class FileReaderTest
    {
        [TestMethod]
        public void ReadCSVFileTest1()
        {
            FileReader fileReader = new FileReader();
            fileReader.ReadCSVFile(@"..\..\..\Data\IrisData.csv");
            int lineNumbers = fileReader.GetLineNumber();
            Assert.AreEqual(lineNumbers, 151);
        }

    }
}
