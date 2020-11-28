using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame
{
    class Player
    {
        static public List<int[]> coordStory = new List<int[]>();
        static public string nowWord;
        static public List<string> wordsList = new List<string>();

        static public void CreateNewPlayer()
        {
            coordStory.RemoveRange(0, coordStory.Count);
            nowWord = string.Empty;
            wordsList.RemoveRange(0, wordsList.Count);
        }
    }
}
