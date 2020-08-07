using System;
using System.IO;

namespace AdventCode2019_2
{
    class Program
    {
        static string[] m_data; //Contains the data split into array of data without blank space from each line delimiter.
        static string[] m_dataSplit; //Contains the data split into array without commas.
        static int[] m_dataConvert; //Contains the same data than m_dataSplit, but in integer format.
        /// <summary>
        /// Method master from the program
        /// </summary>
        /// <param name="args">Arguments to launch</param>
        static void Main(string[] args)
        {
            int[] m_dataConvertInitial; //Contains the same data than m_dataSplit, but with a logic of constant one.
            FileManager m_fmDataFile = new FileManager();
            m_data = m_fmDataFile.PopulateArrayOfData((m_fmDataFile.GetAppRoot("Program.cs").Split("Program.cs")[0]) + @"\input.txt");
            m_dataSplit = m_data[0].Split(',');
            m_dataConvert = new int[m_dataSplit.Length];
            m_dataConvertInitial = new int[m_dataSplit.Length];
            try
            {
                for (int i = 0; i < m_dataConvert.Length; i++)
                {
                    m_dataConvert[i] = int.Parse(m_dataSplit[i]);
                }
                for(int i = 0; i < m_dataConvert.Length;i++)
                {
                    m_dataConvertInitial[i] = int.Parse(m_dataSplit[i]);
                }

                m_dataConvert = CalculateDataInput(m_dataConvert);
                string m_dataToWrite = "";
                for(int i = 0; i < m_dataConvert.Length;i++)
                {
                    m_dataToWrite += m_dataConvert[i] + ",";
                }
                m_dataToWrite = m_dataToWrite[0..^1];
                m_fmDataFile.WriteData((m_fmDataFile.GetAppRoot("Program.cs").Split("Program.cs")[0]) + @"\inputResult.txt",m_dataToWrite);
                int[] m_result = GetDataInputs(m_fmDataFile, (m_fmDataFile.GetAppRoot("Program.cs").Split("Program.cs")[0]) + @"\input.txt");
                string m_resultData = "";
                for(int i = 0; i < m_result.Length;i++)
                {
                    m_resultData += m_result[0] + ",";
                }
                m_resultData = m_resultData[0..^1];
                m_fmDataFile.WriteData((m_fmDataFile.GetAppRoot("Program.cs").Split("Program.cs")[0]) + @"\inputResult2.txt", m_resultData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Method to calculate the placement of each data in the file
        /// </summary>
        /// <param name="p_data">The data with the positions</param>
        static int[] CalculateDataInput(int[] p_data)
        {
                for (int i = 0; i < p_data.Length; i += 4)
                {
                    int m_posFinal = p_data[3 + i];
                    if (p_data[i] != 99)
                    {
                        if (p_data[i] == 1) //For addition
                        {
                            p_data[m_posFinal] = p_data[p_data[1 + i]] + p_data[p_data[2 + i]];
                        }
                        else if (p_data[i] == 2) //For multiplication
                        {
                            p_data[m_posFinal] = p_data[p_data[1 + i]] * p_data[p_data[2 + i]];
                        }
                        if(p_data[0] == 19690720)
                        {
                        break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            return p_data;
        }

        /// <summary>
        /// Method to find a pair of value and noun in the way (noun,value) generates automatically between 0 and 99 respectivily for the noun and the verb. 
        /// The noun and the verb can be two different numbers.
        /// </summary>
        /// <param name="p_fmDataFile">The file manager</param>
        /// <param name="p_DataFilePath">The path to the data file</param>
        /// <returns>The data with the pair of (noun, value) that cause 19690720 on first address of the data file (0)</returns>
        static int[] GetDataInputs(FileManager p_fmDataFile, string p_DataFilePath)
        {
            string[] m_dataInit = p_fmDataFile.PopulateArrayOfData(p_DataFilePath);
            string[] m_dataSplit = m_dataInit[0].Split(',');
            int[] m_dataInitial = new int[m_dataSplit.Length];
            for (int i = 0; i < m_dataSplit.Length; i++)
            {
                m_dataInitial[i] = int.Parse(m_dataSplit[i]);
            }
            for (int j = 0; j < 100;j++)
            {
                for(int i = 0; i < 100;i++)
                {
                    Console.WriteLine(String.Format("Valeur Pos 0 : {0}, Valeur Pos 1: {1}, Valeur Pos 2: {2}", m_dataInitial[0], i, j));
                    m_dataInitial[1] = i;
                    m_dataInitial[2] = j;
                    CalculateDataInput(m_dataInitial);
                    if(m_dataInitial[0] == 19690720)
                    {
                        break;
                    }
                    else
                    {
                        m_dataInit = p_fmDataFile.PopulateArrayOfData(p_DataFilePath);
                        m_dataSplit = m_dataInit[0].Split(',');
                        m_dataInitial = new int[m_dataSplit.Length];
                        for (int l = 0; l < m_dataSplit.Length; l++)
                        {
                            m_dataInitial[l] = int.Parse(m_dataSplit[l]);
                        }
                        for (int l = 0; l < m_dataSplit.Length; l++)
                        {
                            m_dataInitial[l] = int.Parse(m_dataSplit[l]);
                        }
                    }
                }
                if(m_dataInitial[0] == 19690720)
                {
                    int result = 100 * m_dataInitial[1] + m_dataInitial[2];
                    Console.WriteLine("The result is : " + result.ToString());
                    break;
                }
            }
            return m_dataInitial;
        }

    }
}
