using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_HW_n1_pifagor
{
    internal class Program
    {
        public const string path = "C:\\Users\\Maksim\\source\\repos\\CS_HW_n1_pifagor";
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Аргументы командной строки не переданы.");
                return;
            }
            for (int i = 0; i < args.Length; i++)
            {
                try
                {
                    int tmp = int.Parse(args[i]);
                    WriteToFile(PifagorTable(tmp) + "\n");
                }
                catch (Exception e)
                {

                    Console.WriteLine($"{args[i]}: {e}");

                }

            }
            /*
            int[] arr = new int[] {1, 9};
            for (int i = 0; i < arr.Length; i++)
            {
                
                    int tmp = arr[i]; 
                    WriteToFile(PifagorTable(tmp) + "\n");
                
                

            }
            */
        }

        public static string PifagorTable(int limitDigit)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 1; i <= limitDigit; i++) 
            { 
                for(int j = 1; j <= limitDigit; j++)
                {
                    string str = $"{i} X {j} = {i*j}\t";
                    Console.Write(str);
                    sb.Append(str);
                }
                Console.WriteLine();
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public static void WriteToFile(string str)
        {
            
            string file_path = path + "\\output_" + DateToFileName();
            using (FileStream fstream = new FileStream(file_path, FileMode.Append, FileAccess.Write))
            {
                byte[] writeText = Encoding.Unicode.GetBytes(str);
                fstream.Write(writeText, 0, writeText.Length);
            }
        }

        public static string DateToFileName()
        {
            string date = "";
            date = DateTime.Now.ToString();
            StringBuilder newDate = new StringBuilder();
            for (int i = 0; i < date.Length; i++)
            {
                if (date[i] == ':')
                {
                    newDate.Append('_');
                }
                else
                {
                    newDate.Append(date[i]);
                }
            }
            return newDate.ToString();
        }

    }

    
}
