using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KUA.LOGIC;
using System.IO;

namespace KUA.CONSOLE.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StringBuilder str = readFile(System.Configuration.ConfigurationManager.AppSettings["InputFile"]);
                StringBuilder strOut = new StringBuilder();
                ChessBoardManager.Instance.ClearBoards();

                ChessBoardManager.Instance.LoadBoards(str);

                strOut = ChessBoardManager.Instance.FindKingInCheck();




                WriteFile(System.Configuration.ConfigurationManager.AppSettings["OutputFile"], strOut);

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error : "  + ex.ToString());
                Console.ReadLine();
            }
            
        }
        public static StringBuilder readFile(string FileName)
        {
            string filePath = System.Environment.CurrentDirectory + @"\" + FileName;
            StringBuilder Sb = new StringBuilder();
            using (StreamReader Reader = new StreamReader(filePath))
            {
                Sb.Append(Reader.ReadToEnd());
                {
                    //Console.WriteLine("The File is read");
                }
            }

            return Sb;
        }
        public static void WriteFile(string FileName, StringBuilder outMessage)
        {
            string filePath = System.Environment.CurrentDirectory + @"\" + FileName;
            System.IO.File.WriteAllText(filePath, outMessage.ToString());

        }

    }
}
