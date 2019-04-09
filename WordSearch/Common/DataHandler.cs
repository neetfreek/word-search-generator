using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Collections.Generic;

// Responsible for retrieving list of words from DataWords.xml, seperating string into string[], cleaning words

namespace WordSearch.Common
{
    public static class DataHandler
    {
        public static string[] HandleListLoad(string nameList)
        {
            string listWordsString = LoadListWords(nameList);
            string[] listWordsRaw = SeperateWords(listWordsString);
            string[] listWordsClean = CleanWords(listWordsRaw);
            string[] words = Helper.CaptitaliseAll(listWordsClean);

            return words;
        }

        // return STRING of specified list of words in DataWords.xml
        private static string LoadListWords(string nameListWords)
        {                       
            XElement dataWords = XElement.Parse(Properties.Resources.DataWords);

            string list = (string)
                (from el in dataWords.Descendants(nameListWords)
                 select el).First();

            return list;
        }

        // return array of seperated STRING words from given STRING
        private static string[] SeperateWords(string listWords)
        {
            char[] delimiters = new char[] { ',', ' ', ';' };

            string[] words = listWords.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            return words;
        }

        // Return string with all characters save a-z removed
        private static string[] CleanWords(string[] listWords)
        {
            List<string> wordsClean = new List<string>();

            for (int counter = 0; counter < listWords.Length; counter++)
            {
                string copy = Regex.Replace(listWords[counter], "[^A-Za-z]", "");
                wordsClean.Add(copy);
            }
            return wordsClean.ToArray();
        }
    }
}
