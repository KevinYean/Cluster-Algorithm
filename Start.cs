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

        static void Main(string[] args)
        {
            Start main = new Start(@"..\..\Data\DistanceSample1D.csv");
            main.Begin();
        }

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

        public void Begin()
        {
            Console.WriteLine("Start");
            int dataSize = GetDataListSize();
            /*foreach(DataPoint data in dataList)
            {
                Console.WriteLine(data.ToStringValues());
            }*/

            //Clustering
            RunSingleLinkage();

            Console.ReadLine();
        }

        public void RunSingleLinkage()
        {
            //Testing SingleLinkage on Sample1D set
            SingleLinkage singleLinkage = new SingleLinkage(2, dataList);
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
                newDataPoint.SetData(dataValueIntList.ToArray());
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
