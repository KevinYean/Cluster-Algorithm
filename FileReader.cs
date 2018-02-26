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
        private string attributes;
        private int lineNumber;
        private List<string> dataStringList;

        /// <summary>
        /// Initializes a newly created FileReader.
        /// </summary>
        public FileReader()
        {
            lineNumber = 0;
            dataStringList = new List<string>();      
        }

        /// <summary>
        /// Saves the text information into dataStringList which holds the information retrieved from a CSV file.
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
        /// Returns the list of string dataStringList.
        /// </summary>
        /// <returns></returns>
        public List<string> GetDataStringList()
        {
            return dataStringList;
        }

        /// <summary>
        /// Returns the string attributes which contains all the labels
        /// </summary>
        /// <returns></returns>
        public string GetAttributes()
        {
            return attributes;
        }

        /// <summary>
        /// Returns the line number of the most recently read file.
        /// </summary>
        /// <returns></returns>
        public int GetLineNumber()
        {
            return lineNumber;
        }

    }
}
