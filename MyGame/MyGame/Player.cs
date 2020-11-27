using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame
{
    class Player
    {
        static public List<int[]> coordStory = new List<int[]>();
        static public string wordNow;
        static public List<string> wordsList = new List<string>();

        static public void CreateNewPlayer()
        {
            coordStory.RemoveRange(0, coordStory.Count);
            wordNow = string.Empty;
            wordsList.RemoveRange(0, wordsList.Count);
        }
    }
}
