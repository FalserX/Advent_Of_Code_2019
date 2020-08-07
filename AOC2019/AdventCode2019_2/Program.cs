using System;

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
            FileManager m_fmDataFile = new FileManager();
            m_data = m_fmDataFile.PopulateArrayOfData((m_fmDataFile.GetAppRoot("Program.cs").Split("Program.cs")[0]) + @"\input.txt");
            m_dataSplit = m_data[0].Split(',');
            m_dataConvert = new int[m_dataSplit.Length];
            try
            {
                for (int i = 0; i < m_dataConvert.Length; i++)
                {
                    m_dataConvert[i] = int.Parse(m_dataSplit[i]);
                }

                for(int i = 0; i < m_dataConvert.Length;i+=4)
                {
                    int posFinal = m_dataConvert[3 + i];
                    if (m_dataConvert[i] != 99)
                    {
                        if (m_dataConvert[i] == 1) //For addition
                        {
                            m_dataConvert[posFinal] = m_dataConvert[m_dataConvert[1 + i]] + m_dataConvert[m_dataConvert[2 + i]];
                        }
                        else if (m_dataConvert[i] == 2) //For multiplication
                        {
                            m_dataConvert[posFinal] = m_dataConvert[m_dataConvert[1 + i]] * m_dataConvert[m_dataConvert[2 + i]];
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                string m_dataReceive = "";
                for(int i = 0; i < m_dataConvert.Length;i++)
                {
                    m_dataReceive += m_dataConvert[i].ToString() + ",";
                }
                m_fmDataFile.WriteData((m_fmDataFile.GetAppRoot("Program.cs").Split("Program.cs")[0]) + @"\inputResult.txt", 
                                        m_dataReceive.Substring(0, m_dataReceive.Length - 1));

                

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
