using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ObjectLibrary;

namespace FileParserNetStandard {
    
    //public class Person { }  // temp class delete this when Person is referenced from dll
    
    public class PersonHandler {
        public List<Person> People = new List<Person>();

        /// <summary>
        /// Converts List of list of strings into Person objects for People attribute.
        /// </summary>
        /// <param name="people"></param>
        public PersonHandler(List<List<string>> people) {

            foreach (List<string> row in people.Skip(1))
            {
                People
                    .Add(new Person(int
                    .Parse(row[0]), row[1], row[2], new DateTime(long
                    .Parse(row[3]))));
            }
        }

        /// <summary>
        /// Gets oldest people
        /// </summary>
        /// <returns></returns>
        public List<Person> GetOldest()
        {
            return People
                .Where(person => person.Dob == People
                .Min(oldest => oldest.Dob))
                .ToList();
        }

        /// <summary>
        /// Gets string (from ToString) of Person from given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetString(int id)
        {
            return People
                .FirstOrDefault(person => person.Id == id)
                .ToString(); //-- return result here
        }

        public List<Person> GetOrderBySurname() {
            return People
                .OrderBy(person => person.Surname)
                .ToList();  //-- return result here
        }

        /// <summary>
        /// Returns number of people with surname starting with a given string.  Allows case-sensitive and case-insensitive searches
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="caseSensitive"></param>
        /// <returns></returns>
        public int GetNumSurnameBegins(string searchTerm, bool caseSensitive) {

            return People
                .Count(person => person.Surname
                .StartsWith(searchTerm, (caseSensitive == false), null));  //-- return result here
        }

        /// <summary>
        /// Returns a string with date and number of people with that date of birth.  Two values seperated by a tab.  Results ordered by date.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAmountBornOnEachDate() {
            List<string> result = new List<string>();
            //separate task into: return grouping as list of datetimes
            //then: count and combine to string with tab and add to result list
            //OR find linq method
            //asgjhdgadhhdgfffffffffffffff
            //Check .Key (after grouping statement)
            //then foreach result add

            var group = People
                .OrderBy(date => date.Dob)
                .GroupBy(person => person.Dob).ToList();

            foreach (var dtp in group)
            {
                result.Add(dtp.Key + "\t" + dtp.Count());
            }

            return result;
              //-- return result here
        }
    }
}