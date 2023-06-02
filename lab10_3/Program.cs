using System;
using System.IO;

namespace lab10_3
{
    class Program
    {
        static void Main()
        {
            DoSomething(LogToFile);
            DoSomething(Console.WriteLine);
            Console.ReadKey();
        }

        static void DoSomething(Action<string> log)
        {
            log(DateTime.Now + ": DoSomething()");
        }

        static void LogToFile(string message)
        {
            string myDocsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string logFilePath = Path.Combine(myDocsPath, "log.txt");
            File.AppendAllText(logFilePath, message + Environment.NewLine);
        }
    }
}
