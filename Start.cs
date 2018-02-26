using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster_Algorithm
{
    public class Start
    {
        private List<DataPoint> dataList;
        List<string> dataStringList;
        private string attributes;

        /// <summary>
        /// Main method that creates a new Start class with the CSV file path as the string parameter.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Start main = new Start(@"..\..\Data\DistanceSample3D.csv");
            main.Begin();
        }

        /// <summary>
        /// Initializes a constructor which reads the file at the given filepath and converts to usuable data.
        /// </summary>
        /// <param name="filePath"></param>
        public Start(string filePath)
        {
            dataList = new List<DataPoint>();
            attributes = "";


            FileReader fileReader = new FileReader();
            fileReader.ReadCSVFile(filePath);

            dataStringList = new List<string>(fileReader.GetDataStringList());
            attributes = fileReader.GetAttributes();
            ConvertDataString();
        
        }

        /// <summary>
        /// Method launches whichever clustering method is preferred.
        /// </summary>
        public void Begin()
        {
            Console.WriteLine("Start");
            RunSingleLinkage();
            Console.ReadLine();
        }

        /// <summary>
        /// Method runs singlelinkage on the data that was taken
        /// </summary>
        public void RunSingleLinkage()
        {
            //Testing SingleLinkage on Sample1D set
            SingleLinkage singleLinkage = new SingleLinkage(3, dataList);
            singleLinkage.Run();
            Console.WriteLine(singleLinkage.ClusterPairsToString());
            Console.WriteLine("Total Number of ClusterPairs:" + singleLinkage.GetClusterPairsCount());
            Console.WriteLine(singleLinkage.ClustersToString());
        }

        /// <summary>
        /// Convert the dataStringList into an Int List then save each line as a data point.
        /// </summary>
        public void ConvertDataString()
        {
            //Convert the string of attributes names into a list.
            List<string> attributeNames = attributes.Split(',').ToList();

            //For each elements in the dataStringList, convert all values except the last row into
            //an float then save the values to DataPoint and the last one as the label.
            foreach (string line in dataStringList)
            {
                List<string> dataValueList = new List<string>();
                dataValueList = line.Split(',').ToList();

                //Saves the label before removing it from the list
                string label = dataValueList[dataValueList.Count-1];
                dataValueList.RemoveAt(dataValueList.Count - 1);

                List<float> dataValueIntList = new List<float>();
                dataValueIntList = dataValueList.ConvertAll(float.Parse);

                DataPoint newDataPoint = new DataPoint(attributeNames.Count);
                newDataPoint.SetValues(dataValueIntList.ToArray());
                newDataPoint.SetLabel(label);

                dataList.Add(newDataPoint);

                //Console.WriteLine(line);
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
    }
}
