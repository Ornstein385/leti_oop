using System;
using System.IO;

namespace lab7_3
{
    public class CopyFileUpper
    {
        public static void Main()
        {
            string sFrom, sTo;
            Console.WriteLine("Enter input file name:");
            sFrom = Console.ReadLine();
            Console.WriteLine("Enter output file name:");
            sTo = Console.ReadLine();

            StreamReader srFrom;
            StreamWriter swTo;

            try
            {
                srFrom = new StreamReader(sFrom);
                swTo = new StreamWriter(sTo);

                string sBuffer = srFrom.ReadToEnd();
                sBuffer = sBuffer.ToUpper();
                swTo.WriteLine(sBuffer);

                srFrom.Close();
                swTo.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
