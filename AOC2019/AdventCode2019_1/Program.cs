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
            FileManager m_fm = new FileManager();
            string m_strGetRoot = m_fm.GetAppRoot("Program.cs");
            m_strGetRoot = m_strGetRoot.Split("Program.cs")[0];
            strDataSplit = m_fm.PopulateArrayOfData(m_strGetRoot + @"\input.txt");
            iDataSplitConvert = new int[strDataSplit.Length];
            try
            {
                for (int i = 0; i < strDataSplit.Length; i++)
                {
                    iDataSplitConvert[i] = int.Parse(strDataSplit[i]);
                }

                Console.WriteLine("Part 1: " +SumOfData(iDataSplitConvert));
                Console.WriteLine("Part 2: " + RecurSumOfData(iDataSplitConvert));
            }
            catch(Exception m_e)
            {
                Console.WriteLine(m_e.Message);
            }
        }
        /// <summary>
        /// Method to get the sum of all of data get from a text file
        /// </summary>
        /// <param name="p_iData">The array of data in int format</param>
        /// <returns>The sum of the data</returns>
        static int SumOfData(int[] p_iData)
        {
            int m_sum = 0;
            for(int i = 0; i < p_iData.Length;i++)
            {
                m_sum += (p_iData[i] / 3) - 2;
            }
            return m_sum;
        }

        /// <summary>
        /// Method that calculate the result of all the cell data from a text file.
        /// </summary>
        /// <param name="p_iData">The data of cells in a integer array</param>
        /// <returns>The sum of all cells</returns>
        static int RecurSumOfData(int[] p_iData)
        {
            int m_sum = 0;
            for(int i = 0; i < p_iData.Length;i++)
            {
                p_iData[i] = PrecurSumOfData(p_iData[i]);
            }
            for (int i = 0; i < p_iData.Length;i++)
            {
                m_sum += p_iData[i];
            }
            return m_sum;
        }
        /// <summary>
        /// Method that can calculate the sum of each data in array (Recursive formula)
        /// </summary>
        /// <param name="p_data">The cell that contains the data</param>
        /// <returns>The sum of the data cell (Result of recursive)</returns>
        private static int PrecurSumOfData(int p_data)
        {
            int p_dataDivide = (p_data / 3) - 2;
            int p_sum = 0;
            if (p_dataDivide > 0)
            {
                p_sum += p_dataDivide + PrecurSumOfData(p_dataDivide);
            }
            return p_sum;    
        }
    }
}
