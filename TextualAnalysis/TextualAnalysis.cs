using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextualAnalysis
{
    public class TextualAnalysis
    {
        public static string stopWordFilePath = "../../../Data/stop-words.txt";

        public TextualAnalysis()
        {
        }


        public static Dictionary<string, int> ComputeWordFrequencies(string s, bool ignoreStopWords = false)
        {
            var wordCounts = new Dictionary<string, int>();
            // s = "all the faith he had had had had no effect."

            // remove punctuation
            var cleanString = Regex.Replace(s, @"[^\w\s]", "");


            // split the string into words (filtering out the empty strings)
            var words = cleanString.ToLower()
                        .Split()
                        .Where( s => s!="" );

            var stopWords = GetStopWordsFromFile(stopWordFilePath);
            HashSet<string> stopWordHashSet = new HashSet<string>();
            foreach(var word in stopWords)
            {
                stopWordHashSet.Add(word);
            }

            // foreach word process it
                // if it's in the hashtable, then increment the count
                // else make a new entry with a count of 1

            foreach (string word in words)
            {
                // if ignoreStopWords is true and word is not a stop word, then do this

                if (ignoreStopWords && stopWordHashSet.Contains(word))
                {
                    continue;
                }
                if (wordCounts.ContainsKey(word))
                {
                    wordCounts[word]++;
                }
                else
                {
                    wordCounts[word] = 1;
                }
            }

            return wordCounts;
        }


        public static Dictionary<string, int> ComputeWordFrequenciesFromFile(string path, bool ignoreStopWords = false)
        {
            string text = System.IO.File.ReadAllText(path);

            Dictionary<string, int> Result = ComputeWordFrequencies(text, ignoreStopWords);

            return Result;
        }

        private static string[] GetStopWordsFromFile(string path)
        {
            var rawLines = System.IO.File.ReadAllLines(path);
            var lines = new List<string>();

            foreach (var line in rawLines)
            {
                // ignore blank lines
                if (line.Trim() != "")
                {
                    lines.Add(line.Trim().ToLower());
                }
            }

            return lines.ToArray();
        }

    }
}
