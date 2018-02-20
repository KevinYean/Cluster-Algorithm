using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cluster_Algorithm;

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
    }
}
