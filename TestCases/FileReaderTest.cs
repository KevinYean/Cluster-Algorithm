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
            fileReader.ReadCSVFile(@"..\..\..\IrisData.csv");
            int lineNumbers = fileReader.GetLineNumber();
            Assert.AreEqual(lineNumbers, 150);
        }

        [TestMethod]
        public void ConvertDataStringTest1()
        {
            FileReader fileReader = new FileReader();
            fileReader.ReadCSVFile(@"..\..\..\Sample1D.csv");
            fileReader.ConvertDataString();
            int dataSize = fileReader.GetDataListSize();
            Assert.AreEqual(dataSize, 9);
        }

        [TestMethod]
        public void GetDataPointsTest1()
        {
            FileReader fileReader = new FileReader();
            fileReader.ReadCSVFile(@"..\..\..\Sample1D.csv");
            fileReader.ConvertDataString();
            List<DataPoint> data = fileReader.GetDataPoints();
            Assert.AreEqual(data.Count, 9);
        }
    }
}
