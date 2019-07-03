using System.Collections.Generic;
using System.Linq;

namespace FileParserNetStandard {
    public class DataParser {
        

        /// <summary>
        /// Strips any whitespace before and after a data value.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripWhiteSpace(List<List<string>> data) {

            List<List<string>> newData = new List<List<string>>();

            foreach (List<string> row in data)
            {
                newData.Add(new List<string>());
                foreach (string item in row)
                {
                    newData[data
                        .IndexOf(row)]
                        .Add(item
                        .Trim());
                }
            }
            return newData;
        }

        /// <summary>
        /// Strips quotes from beginning and end of each data value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripQuotes(List<List<string>> data) {
            List<List<string>> newData = new List<List<string>>();

            foreach (List<string> row in data)
            {
                newData.Add(new List<string>());
                foreach (string item in row)
                {
                    newData[data
                        .IndexOf(row)]
                        .Add(item
                        .Trim('"'));
                }
            }
            return newData;
        }

    }
}