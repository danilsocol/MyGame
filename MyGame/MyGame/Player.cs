﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame
{
    class Player
    {
        static public int x, y;
        static public int preX, preY;
        static public List<int[]> coordStory = new List<int[]>();
        static public string wordNow;
        static public List<string> wordsList = new List<string>();

        static public void CreateNewPlayer()
        {
            x = 0;
            y = 0;
            preX = 0;
            preY = 0;
            coordStory.RemoveRange(0, coordStory.Count);
            wordNow = string.Empty;
            wordsList.RemoveRange(0, wordsList.Count);
        }
    }
}
