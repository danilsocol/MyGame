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

        public static string[] ReadOldNames()
        {
            return File.ReadAllLines("Names.txt");
        }

        public static string[] ReadOldScore()
        {
            return File.ReadAllLines("Score.txt");
        }

        public static void CreatePlayer(string[] oldNames, string[] oldScore, string name)
        {
            string[] newAndOldNames = new string[oldNames.Length + 1];
            string[] newAndOldScore = new string[oldScore.Length + 1];

            for (int j = 0; j < newAndOldNames.Length - 1; j++)
            {
                if (j + 2 == newAndOldNames.Length)
                {
                    newAndOldNames[j] = name;
                    newAndOldNames[j + 1] = "";

                    newAndOldScore[j] = "0";
                    newAndOldScore[j + 1] = "";
                    j++;
                }
                else
                {
                    newAndOldNames[j] = oldNames[j];
                    newAndOldScore[j] = oldScore[j];
                }
            }

            StreamWriter str = new StreamWriter("Names.txt");
            for (int k = 0; k < newAndOldNames.Length; k++)
            {
                str.WriteLine(newAndOldNames[k]);
            }
            str.Close();

            StreamWriter scr = new StreamWriter("Score.txt");
            for (int k = 0; k < newAndOldScore.Length; k++)
            {
                scr.WriteLine(newAndOldScore[k]);
            }
            scr.Close();

            Player.score = 0;
        }
        public static void Victory()
        {
            string[] oldScore = ReadOldScore();
            oldScore[Player.indexPlayer] = Convert.ToString(Player.score);

            StreamWriter scr = new StreamWriter("Score.txt");
            for (int k = 0; k < oldScore.Length; k++)
            {
                scr.WriteLine(oldScore[k]);
            }
            scr.Close();
        }

        public static int[] FindTopTen(string[] score)
        {
            string[] countScore = new string[score.Length];

            for (int l = 0; l < countScore.Length; l++)
            {
                countScore[l] = score[l];
            }


            int[] topTenIndex = new int[10];

            topTenIndex[0] = 0;

            for (int i = 0; i < 10; i++)
            {
                int max = -1;
                for (int j = 0; j < countScore.Length - 1; j++)
                {
                    if (max <= Convert.ToInt32(countScore[j]))
                    {
                        max = Convert.ToInt32(countScore[j]);
                        topTenIndex[i] = j;
                    }
                }
                countScore[topTenIndex[i]] = "-2";
            }
            return topTenIndex;
        }
    }
}

