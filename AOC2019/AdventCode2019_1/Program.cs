using System;

namespace AdventCode2019_1
{
    class Program
    {
        static string[] strDataSplit; //The array of data from a text file.
        static int[] iDataSplitConvert; //The array of data convert from strDataSplit.
        static int[] iDataRequired; //The array of data from which what is required and not the total.
        /// <summary>
        /// Method master from the program
        /// </summary>
        /// <param name="args">Arguments to launch</param>
        static void Main(string[] args)
        {
            FileManager m_fm = new FileManager();
            string m_strGetRoot = m_fm.GetAppRoot("Program.cs");
            m_strGetRoot = m_strGetRoot.Split("Program.cs")[0];
            strDataSplit = m_fm.PopulateArrayOfData(m_strGetRoot + @"\input1_2.txt");
            iDataSplitConvert = new int[strDataSplit.Length];
            try
            {
                for (int i = 0; i < strDataSplit.Length; i++)
                {
                    iDataSplitConvert[i] = int.Parse(strDataSplit[i]);
                }

                Console.WriteLine(SumOfData(iDataSplitConvert));
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
        
        static int RecurSumOfData(int[] p_iData)
        {
            return 0;
        }

        static private int _RecurSumOfData(int p_d)
        {
            return 0;
        }
    }
}
