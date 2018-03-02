﻿using System;
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
            //Start main = new Start(@"..\..\Data\SeedData.csv");
            //Start main = new Start(@"..\..\Data\KnowledgeData.csv");
            Start main = new Start(@"..\..\Data\IrisData.csv");
            main.Begin(3); // int is the Number of clusters to aim for 3 for Iris and Seet and 4 for Knowledge
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
        public void Begin(int kCluster)
        {
            Console.WriteLine("Begin Clustering-- ");
            Console.WriteLine();
            RunSingleLinkage(kCluster);
            RunCompleteLinkage(kCluster);
            RunAverageLinkage(kCluster);
            RunLloyd(kCluster, 100);
            RunDBScan(.39f, 3, kCluster);
            Console.WriteLine("Finished Clustering-- ");
            Console.ReadLine();
        }

        /// <summary>
        /// Method runs singlelinkage on the data that was taken
        /// </summary>
        public void RunSingleLinkage(int kCluster)
        {
            Console.WriteLine("SingleLinkage");
            SingleLinkage singleLinkage = new SingleLinkage(kCluster, dataList);
            singleLinkage.Run();
            RunHammingDistance(kCluster, singleLinkage.GetClusters());
            Console.WriteLine(singleLinkage.ClusterGroupToString());
        }

        /// <summary>
        /// Method runs CompleteLinkage on the data that was taken
        /// </summary>
        public void RunCompleteLinkage(int kCluster)
        {
            Console.WriteLine("CompleteLinkage");
            CompleteLinkage completeLinkage = new CompleteLinkage(kCluster, dataList);
            completeLinkage.Run();
            RunHammingDistance(kCluster, completeLinkage.GetClusters());
            Console.WriteLine(completeLinkage.ClusterGroupToString());
        }

        /// <summary>
        /// Method runs singlelinkage on the data that was taken
        /// </summary>
        public void RunAverageLinkage(int kCluster)
        {
            Console.WriteLine("AverageLinkage");
            AverageLinkage averageLinkage = new AverageLinkage(kCluster, dataList);
            averageLinkage.Run();
            RunHammingDistance(kCluster, averageLinkage.GetClusters());
            Console.WriteLine(averageLinkage.ClusterGroupToString());
        }

        /// <summary>
        /// Methods runs Lloyd's Clustering Algorithm also known as K-mean
        /// </summary>
        /// <param name="kCluster"></param>
        public void RunLloyd(int kCluster,int loops)
        {
            Console.WriteLine("Lloyds/K Mean Cluster");
            Lloyds lloyd = new Lloyds(kCluster, dataList);
            lloyd.Run(loops);
            RunHammingDistance(kCluster, lloyd.GetBestClusters());
            Console.WriteLine(lloyd.ClusterGroupToString());
        }


        /// <summary>
        /// Methods runs Lloyd's Clustering Algorithm also known as K-mean
        /// </summary>
        /// <param name="kCluster"></param>
        public void RunDBScan(float distance, int minPts,int kCluster)
        {
            Console.WriteLine("DBScan Cluster");
            DBSCAN dbscan = new DBSCAN(dataList);
            dbscan.Run(distance,minPts);
            Console.WriteLine(dbscan.ClusterGroupToString());
            RunHammingDistance(kCluster, dbscan.clusterList);
            RunHammingDistanceNoOutliers(kCluster, dbscan.clusterList,dbscan.outliers);
            //Console.WriteLine(lloyd.ClusterGroupToString());
        }

        /// <summary>
        /// Method runs the hamming distance with a list of cluster to the target truth.
        /// </summary>
        public void RunHammingDistance(int kCluster,List<Cluster> clustersC)
        {
            HammingDistance ham = new HammingDistance(clustersC);
            ham.SetTargetClusterList(kCluster, dataList);
            Console.WriteLine("Hamming Distance---------:" + ham.GetHammingDistance());
            //RunHammingDistance(kCluster, SetTargetClusterListNoOutliers


        }

        /// <summary>
        /// Method runs the hamming distance with a list of cluster to the target truth.
        /// </summary>
        public void RunHammingDistanceNoOutliers(int kCluster, List<Cluster> clustersC, List<DataPoint> outliers )
        {
            HammingDistance ham = new HammingDistance(clustersC);
            //ham.SetTargetClusterList(kCluster, dataList);
            ham.SetTargetClusterListNoOutliers(kCluster, dataList,outliers);
            Console.WriteLine("Hamming Distance No Outliers:" + ham.GetHammingDistance());
            //RunHammingDistance(kCluster, SetTargetClusterListNoOutliers


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
            int id = 1;
            foreach (string line in dataStringList)
            {
                List<string> dataValueList = new List<string>();
                dataValueList = line.Split(',').ToList();

                //Saves the label before removing it from the list
                string label = dataValueList[dataValueList.Count-1];
                dataValueList.RemoveAt(dataValueList.Count - 1);

                List<float> dataValueIntList = new List<float>();
                dataValueIntList = dataValueList.ConvertAll(float.Parse);

                DataPoint newDataPoint = new DataPoint(attributeNames.Count,id);
                newDataPoint.SetValues(dataValueIntList.ToArray());
                newDataPoint.SetLabel(label);

                dataList.Add(newDataPoint);
                id++;
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

        //---------------------To Move Somewhere else -----------------------------//
        //Figureout distance using crude k neightboor
        public void eDistance(int minPts)
        {
            float totalAvg = 0;
            foreach (DataPoint dataPoint in dataList)
            {
                List<KeyValuePair<int, float>> distanceList = new List<KeyValuePair<int, float>>();
                for (int i = 0; i < minPts-1; i++)
                {
                    KeyValuePair<int, float> tempPair = new KeyValuePair<int, float>(-1, -1);
                    distanceList.Add(tempPair);
                }
                foreach(DataPoint dataK in dataList)
                {
                     if(dataPoint.GetID() != dataK.GetID())
                     {
                        float tempDistance = dataPoint.GetDistanceDataPoint(dataK.GetValues());
                        if (tempDistance < distanceList[distanceList.Count()-1].Value || distanceList[0].Value == -1)
                        {
                            if (distanceList[0].Value == -1)
                            {
                                distanceList.RemoveAt(0);
                            }
                            else
                            {
                                distanceList.RemoveAt(distanceList.Count() - 1);
                            }
                            KeyValuePair<int, float> tempPair = new KeyValuePair<int, float>(dataK.GetID(), tempDistance);
                            distanceList.Add(tempPair);
                            distanceList = distanceList.OrderBy(o => o.Value).ToList();
                        }
                     }
                 }
                //Console.WriteLine("----");
                float avg = 0;
                foreach(KeyValuePair<int,float> pair in distanceList)
                {
                    //Console.WriteLine(pair.ToString());
                    avg += pair.Value;
                }
                avg = avg / (minPts - 1);
                //Console.WriteLine("Average Distance: " + avg);
                totalAvg += avg;
             }
            totalAvg = totalAvg / dataList.Count();
            Console.WriteLine("Average Distance: " + totalAvg);
             return;
        }
    }
}
