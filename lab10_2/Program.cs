using System;
using System.IO;

namespace lab10_2
{
    class Program
    {
        private delegate void Log(string message);

        static void Main()
        {
            DoSomething(LogToFile);
            DoSomething(delegate (string message) { Console.WriteLine(message); });
            DoSomething(message => Console.WriteLine(message));
            DoSomething(Console.WriteLine);
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
