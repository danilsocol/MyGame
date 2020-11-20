using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyGame
{
    class NewGame
    {
        public static string[] ReadFile()
        {

            var text = File.ReadLines("dictionary.txt");

            string[] words = new string[text.Count()];

            for (int i = 0; i < words.Length; i++) words[i] = text.Skip(i).First().ToUpper();

            return words;

        }


    }
}
