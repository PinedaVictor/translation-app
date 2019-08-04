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
            string path = "file.txt";
            StreamWriter outputFile = new StreamWriter("output.txt");
            List<string> paragraph = new List<string>();
            if (File.Exists(path))
            {
                Console.WriteLine("----------PROGRAM START--------------");
                using (StreamReader reader = new StreamReader(path))
                {
                    string currentLine;
                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        paragraph.Add(currentLine);
                    }
                    IList<TranslationResult> translatedParagraph = Translate(paragraph);
                    foreach(string s in paragraph){
                        outputFile.WriteLine(s);
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