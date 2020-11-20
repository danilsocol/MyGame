using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MyGame
{
    class NewGame
    {
        public static string[] ReadFile()
        {
            string name = Write.ReadName();

            string text = File.ReadAllText("dictionary.txt");

            string[] word = SplitWords(text);

            
        }

        private static string[] SplitWords(string text)
        {
            return text.Split(",");
        }

        //private static void ChoiceOfWords(int numberOfWords)
        //{
        //    Random rnd = new Random();
        //}


    }
}
