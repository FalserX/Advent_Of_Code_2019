using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventCode2019_2
{
    public class FileManager
    {

        public FileManager() { }

        /// <summary>
        /// Method to get the root of the application
        /// </summary>
        /// <param name="p_strFileName">The name of the application</param>
        /// <returns>The path to the root</returns>
        public string GetAppRoot(string p_strFileName)
        {
            var m_execPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Regex m_appRootMatch = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var m_appRoot = m_appRootMatch.Match(m_execPath).Value;
            return Path.Combine(m_appRoot, p_strFileName);
        }

        /// <summary>
        /// Method to populate the array of data string from a text file or another type of file.
        /// </summary>
        /// <param name="p_strPathOfDataFile">The path of the data file</param>\
        /// <returns>The string of data in array form</returns>
        public string[] PopulateArrayOfData(string p_strPathOfDataFile)
        {
            string m_strData = File.ReadAllText(p_strPathOfDataFile);
            return m_strData.Split("\r\n",StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Method to writing, to the file, the data receive
        /// </summary>
        /// <param name="p_strPathOfDataFile">The path of the data file</param>
        /// <param name="p_strData">The data</param>
        public void WriteData(string p_strPathOfDataFile,string p_strData)
        {
            File.WriteAllText(p_strPathOfDataFile,p_strData);
        }

    }
}
