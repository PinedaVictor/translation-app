using System;
using System.IO;
using Google.Cloud.Translation.V2;

namespace uisapp
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "file.txt";
            StreamWriter outputFile = new StreamWriter("output.txt");
            string line = "";
            if (File.Exists(path))
            {
                Console.WriteLine("----------PROGRAM START--------------");
                using (StreamReader reader = new StreamReader(path))
                {
                    string currentLine;
                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        line = Translate(currentLine).TranslatedText;
                        outputFile.WriteLine(line);
                    }
                    outputFile.Close();
                    Console.WriteLine("----------PROGRAM END--------------");
                }
            }
            else
            {
                throw new FileNotFoundException("ERROR: FILE NOT FOUND");
            }
        }
        static TranslationResult Translate(string text)
        {
            var client = TranslationClient.Create();
            return client.TranslateText(text, LanguageCodes.Spanish);
        }
    }
}
