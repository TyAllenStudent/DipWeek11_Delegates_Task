using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using FileParserNetStandard;

//public delegate List<List<string>> Parser(List<List<string>> data);

namespace Delegate_Exercise {
    
    internal class Delegate_Exercise {

        private static List<List<string>> StripHash(List<List<string>> data)
        {
            List<List<string>> newData = new List<List<string>>();

            foreach (List<string> row in data)
            {
                newData.Add(new List<string>());
                foreach (string item in row)
                {
                    newData[data
                        .IndexOf(row)]
                        .Add(item
                        .Trim('#'));
                }
            }
            return newData;
        }

        public static void Main(string[] args) {
            Console.WriteLine("Press any key to sanitise data...");
            Console.ReadKey();
            Console.WriteLine("Working...");

            DataParser dataParser = new DataParser();

            List<List<string>> Stripper(List<List<string>> data) => 
                StripHash(dataParser
                .StripWhiteSpace(dataParser
                .StripQuotes(data)));

            CsvHandler csvHandler = new CsvHandler();

            csvHandler.ProcessCsv(@"C:\Diploma-at-28-April\OOP\Week-11-Delegates-n-stuffz\Files\data.csv", @"C:\Diploma-at-28-April\OOP\Week-11-Delegates-n-stuffz\Files\processed_data.csv", Stripper);

            Console.WriteLine("File cleansed.");
            Console.ReadKey();
        }
    }
}