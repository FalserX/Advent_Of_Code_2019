using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventCode2019_1
{
    public class FileManager
    {

        public FileManager() { }

        /// <summary>
        /// Method to get the root of the application
        /// </summary>
        /// <param name="strFileName">The name of the application</param>
        /// <returns>The path to the root</returns>
        public string GetAppRoot(string strFileName)
        {
            var execPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Regex appRootMatch = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appRootMatch.Match(execPath).Value;
            return Path.Combine(appRoot, strFileName);
        }

        /// <summary>
        /// Method to populate the array of data string from a text file or another type of file.
        /// </summary>
        /// <param name="strPathOfDataFile">The path of the data file</param>\
        /// <returns>The string of data in array form</returns>
        public string[] PopulateArrayOfData(string strPathOfDataFile)
        {
            string strData = File.ReadAllText(strPathOfDataFile);
            return strData.Split("\r\n",StringSplitOptions.RemoveEmptyEntries);
        }


    }
}
