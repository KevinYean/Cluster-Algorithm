using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster_Algorithm
{
    public class FileReader
    {
        private int lineNumber;
        private string attributes;
        private List<string> dataStringList;
        private List<DataPoint> dataList;

        /// <summary>
        /// Initializes a newly created FileReader.
        /// </summary>
        public FileReader()
        {
            lineNumber = 0;
            dataStringList = new List<string>();
            dataList = new List<DataPoint>();
        }

        /// <summary>
        /// Constructs a new variable that holds the information retrived from a CSV file.
        /// </summary>
        /// <param name="filePath"></param>
        public void ReadCSVFile(string filePath)
        {
            lineNumber = 0; //KeepsTrack of the number of lines.
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (lineNumber == 0)
                    {
                        attributes = line;
                    }
                    else
                    {
                        dataStringList.Add(line);
    
                    }
                    lineNumber++;
                }
            }
        }

        /// <summary>
        /// Convert the dataStringList into an Int List then save each line as a data point.
        /// </summary>
        public void ConvertDataString()
        {
            string attributeName = attributes.Split(',').ToList()[0];
            foreach(string line in dataStringList)
            {
                List<string> dataValueList = new List<string>();
                dataValueList = line.Split(',').ToList();

                List<int> dataValueIntList = new List<int>();
                dataValueIntList = dataValueList.ConvertAll(int.Parse);

                DataPoint newDataPoint = new DataPoint(dataValueIntList[0], attributeName);
                dataList.Add(newDataPoint);

                Console.WriteLine(line);
            } 
        }

        /// <summary>
        /// Returns the size of the list of DataPoints.
        /// </summary>
        /// <returns></returns>
        public int GetDataListSize()
        {
            return dataList.Count();
        }

        /// <summary>
        /// Returns the list of DataPoints.
        /// </summary>
        /// <returns></returns>
        public List<DataPoint> GetDataPoints()
        {
            return dataList;
        }

        /// <summary>
        /// Returns the line number of the most recently read file.
        /// </summary>
        /// <returns></returns>
        public int GetLineNumber()
        {
            return lineNumber;
        }

        /// <summary>
        /// Test Method
        /// </summary>
        /// <returns></returns>
        public int Test()
        {
            return 1;
        }
    }
}
