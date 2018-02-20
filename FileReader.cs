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
        public int lineNumber;

        /// <summary>
        /// Initializes a newly created FileReader.
        /// </summary>
        public FileReader()
        {
            lineNumber = 0;
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
                    //Read each line and split each line whenever a ',' is encountered and saved to a list of strings.
                    var line = reader.ReadLine();
                    List<string> dataValueList = new List<string>();
                    dataValueList = line.Split(',').ToList();

                    if (lineNumber == 0) //If LineNumber is the first line, retrieve the attributes of the dataset
                    {
                    }
                    else //Retrieve examples in the dataset.
                    {
                    }
                    lineNumber++;
                }
            }
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
