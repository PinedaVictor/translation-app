using System;
using System.IO;
using Google.Cloud.Translation.V2;
using System.Collections.Generic;

namespace uisapp
{
    class Program
    {
        static void Main(string[] args)
        {
            int paragraphSize = 7;
            string path = "file.txt";
            StreamWriter outputFile = new StreamWriter("output.txt");
            string[] paragraph = new string[paragraphSize];
            int count = 0;
            if (File.Exists(path))
            {
                Console.WriteLine("----------PROGRAM START--------------");
                using (StreamReader reader = new StreamReader(path))
                {
                    // TODO: Loop structure needs to be updated                    
                    string currentLine;                
                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        paragraph[count] = currentLine;                        
                        count++;
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
        static IList<TranslationResult> Translate(IEnumerable<string> text)
        {
            var client = TranslationClient.Create();
            return client.TranslateText(text, LanguageCodes.Spanish);
        }
    }
}