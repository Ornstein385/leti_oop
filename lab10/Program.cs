using System;
using System.IO;

namespace lab10
{
    class Program
    {
        private delegate void Log(string message);

        static void Main()
        {
            DoSomething(LogToFile);
            Console.ReadKey();
        }

        static void DoSomething(Log log)
        {
            log(DateTime.Now + ": log message");
        }

        static void LogToFile(string message)
        {
            string myDocsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string logFilePath = Path.Combine(myDocsPath, "log.txt");
            File.AppendAllText(logFilePath, message + Environment.NewLine);
        }
    }
}
