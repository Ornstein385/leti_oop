using System;

using System.IO;

namespace FileDetails
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filename = args[0];
                Console.WriteLine("Number of arguments: " + args.Length);

                foreach (string arg in args)
                {
                    Console.WriteLine(arg);
                }

                if (File.Exists(filename))
                {
                    using (FileStream fs = new FileStream(filename, FileMode.Open))
                    {
                        using (StreamReader reader = new StreamReader(fs))
                        {
                            int fileLength = (int)fs.Length;
                            char[] contents = new char[fileLength];

                            for (int i = 0; i < fileLength; i++)
                            {
                                contents[i] = (char)reader.Read();
                            }

                            Summarize(contents);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("File not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void Summarize(char[] contents)
        {
            int vowels = 0;
            int consonants = 0;
            int lines = 1;

            foreach (char c in contents)
            {
                if (c == '\n')
                {
                    lines++;
                }
                else if (Char.IsLetter(c))
                {

                    if ("AEIOUYaeiouyАЕИОУЫЭЮЯаеиоуыэюя".IndexOf(c) != -1)
                    {
                        vowels++;
                    }
                    else
                    {
                        consonants++;

                    }
                }
            }

            Console.WriteLine("Всего символов: " + contents.Length);
            Console.WriteLine("Гласные: " + vowels);
            Console.WriteLine("Согласные: " + consonants);
            Console.WriteLine("Строки: " + lines);
        }
    }
}
