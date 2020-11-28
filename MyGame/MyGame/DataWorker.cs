using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyGame
{
    class DataWorker
    {
        public static string[] ReadFile()
        {
            var text = File.ReadLines("dictionary.txt");

            string[] words = new string[text.Count()];

            for (int i = 0; i < words.Length; i++) words[i] = text.Skip(i).First().ToUpper();

            return words;
        }

        public static List<List<string>> ListWord(string[] input)
        {
            string[] allWords = input;
            List<List<string>> setWords = new List<List<string>>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Length > setWords.Count - 1)
                {
                    do
                    {
                        setWords.Add(new List<string>());
                    } while (setWords.Count - 1 < input[i].Length);
                }

                setWords[input[i].Length].Add(input[i]);
            }
            return setWords;
        }
    }
}

