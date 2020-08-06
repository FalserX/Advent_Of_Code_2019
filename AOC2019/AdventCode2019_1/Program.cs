using System;

namespace AdventCode2019_1
{
    class Program
    {
        static string[] strDataSplit; //The array of data from a text file.
        static int[] iDataSplitConvert; //The array of data convert from strDataSplit.
        /// <summary>
        /// Method master from the program
        /// </summary>
        /// <param name="args">Arguments to launch</param>
        static void Main(string[] args)
        {
            FileManager fm = new FileManager();
            string strGetRoot = fm.GetAppRoot("Program.cs");
            strGetRoot = strGetRoot.Split("Program.cs")[0];
            strDataSplit = fm.PopulateArrayOfData(strGetRoot + @"\input.txt");
            iDataSplitConvert = new int[strDataSplit.Length];
            try
            {
                for (int i = 0; i < strDataSplit.Length; i++)
                {
                    iDataSplitConvert[i] = int.Parse(strDataSplit[i]);
                }
                Console.WriteLine(SumOfData(iDataSplitConvert));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Method to get the sum of all of data get from a text file
        /// </summary>
        /// <param name="iData">The array of data in int format</param>
        /// <returns>The sum of the data</returns>
        static int SumOfData(int[] iData)
        {
            int sum = 0;
            for(int i = 0; i < iData.Length;i++)
            {
                sum += (iData[i] / 3) - 2;
            }
            return sum;
        }
        
    }
}
