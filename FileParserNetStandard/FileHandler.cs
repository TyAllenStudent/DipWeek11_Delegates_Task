using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FileParserNetStandard {
    public class FileHandler
    {
        public FileHandler() { }

        /// <summary>
        /// Reads a file returning each line in a list.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<string> ReadFile(string filePath) {
            //List<string> lines = new List<string>();
            //string[] liness = File.ReadAllLines(filePath);
            //return liness.ToList();

            return File
                .ReadAllLines(filePath)
                .Select(lines => lines)
                .ToList();
        }

        /// <summary>
        /// Takes a list of a list of data.  Writes to file, using delimeter to seperate data.  Always overwrites.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="rows"></param>
        public void WriteFile(string filePath, char delimeter, List<List<string>> rows)
        {
            int N = rows.Count;
            string[] newLines = new string[N];

            for (int row = 0; row < N; row++)
            {
                int Nn = rows[row].Count;
                for (int data = 0; data < Nn - 1; data++)
                {
                    newLines[row] += rows[row][data] + delimeter;
                }
                newLines[row] += rows[row].Last();
            }
            File.WriteAllLines(filePath, newLines);
        }

        /// <summary>
        /// Takes a list of strings and seperates based on delimeter.  Returns list of list of strings seperated by delimeter.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="delimeter"></param>
        /// <returns></returns>
        public List<List<string>> ParseData(List<string> data, char delimeter)
        {
            List<List<string>> newData = new List<List<string>>();

            foreach (string line in data)
            {
                newData
                    .Add(line
                    .Split(delimeter)
                    .ToList());
            }
            return newData; //-- return result here
        }
        
        /// <summary>
        /// Takes a list of strings and seperates on comma.  Returns list of list of strings seperated by comma.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> ParseCsv(List<string> data) {

            List<List<string>> newData = new List<List<string>>();

            foreach (string line in data)
            {
                newData
                    .Add(line
                    .Split(Convert.ToChar(','))
                    .ToList());
            }
            return newData; //-- return result here
        }
    }
}