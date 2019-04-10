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
        public static string[] HandleListLoad(string nameList, int sizeList)
        {
            string wordsString = LoadListWords(nameList);
            string wordsStringSanitised = SanitiseWords(wordsString);
            string[] wordsSeperated = SeperateWords(wordsStringSanitised);
            string[] wordsSelected = SetSizeList(wordsSeperated, sizeList);
            string[] words = Helper.CaptitaliseAll(wordsSelected);

            return words;
        }

        public static string[] AllLists()
        {
            XElement dataWords = XElement.Parse(Properties.Resources.DataWords);
            var xElements = dataWords.Elements();
            List<string> listOfLists = new List<string>();

            foreach (var item in xElements)
            {
                listOfLists.Add(item.Name.ToString());
            }
            string[] lists = listOfLists.ToArray();

            return lists;
        }

        // Return STRING of specified list of words from DataWords.xml
        private static string LoadListWords(string nameListWords)
        {                       
            XElement dataWords = XElement.Parse(Properties.Resources.DataWords);

            string list = (string)
                (from el in dataWords.Elements(nameListWords)
                 select el).First();

            return list;
        }

        // Return array of seperated STRING words from given STRING
        private static string[] SeperateWords(string listWords)
        {
            char[] delimiters = new char[] { ',', ' ', ';' };

            string[] words = listWords.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            return words;
        }

        // Return string with all characters except a-z, removed
        private static string SanitiseWords(string listWords)
        {
            string wordsSanitised = Regex.Replace(listWords, "[^A-Za-z ]", "");

            return wordsSanitised;
        }

        // Return STRING array of randomly chosen words in list
        private static string[] SetSizeList(string[] arrayWords, int sizeList)
        {
            bool wordAdded = false;
            List<string> listWords = new List<string>();

            for (int counter = 0; counter < sizeList; counter++)
            {
                Console.WriteLine(counter);
                wordAdded = false;
                while (!wordAdded)
                {
                    // Select word from random integer
                    string wordSelected = arrayWords[Helper.RandomInt(0, arrayWords.Length-1)];
                    // if word not already added to listWords, add
                    if (!listWords.Contains(wordSelected))
                    {
                        listWords.Add(wordSelected);
                        wordAdded = true;
                    }
                }
            }
            return listWords.ToArray();
        }
    }
}