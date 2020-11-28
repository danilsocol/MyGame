using System;
using System.Collections.Generic;


namespace MyGame
{
    class Game
    {
        static public void PlayerMoveAction(int preX,int preY,int x,int y ,Field field, bool isEnter)
        {
            if (!isEnter)
            {
                Write.DrawFieldItem(preX, preY, field.cellColor[preX, preY, 0],
                                             field.cellColor[preX, preY, 1], field);
                Write.DrawFieldItem(x, y, ConsoleColor.Red, ConsoleColor.White, field);

            }
            else
            {
                Write.DrawFieldItem(preX, preY, ConsoleColor.Gray, ConsoleColor.Black, field);
                Write.DrawFieldItem(x, y, ConsoleColor.Red, ConsoleColor.White, field);
                Player.wordNow += field.cellLetter[x, y];
                Write.DrawWord(Player.wordNow, field.xSize, Player.wordsList.Count);
                Player.coordStory.Add(new int[] { x, y });
            }

        }

        static public void PlayerEnterAction(int X, int Y,Field field, ref bool isEnter, string[] allWords)
        {
            if (!isEnter)
            {
                Write.DrawWord(new string(' ', Console.WindowWidth - (field.xSize * 4 + 2)), field.xSize, Player.wordsList.Count);

                if (field.cellColor[X, Y, 0] == ConsoleColor.Black)
                {
                    Write.DrawFieldItem(X, Y, ConsoleColor.Gray, ConsoleColor.Black, field);
                    Player.wordNow += field.cellLetter[X, Y];
                    Write.DrawWord(Player.wordNow, field.xSize, Player.wordsList.Count);
                    Player.coordStory.Add(new int[] { X, Y });
                }
                else
                    isEnter = !isEnter;
            }
            else
            {
                if (field.wordsList.Contains(Player.wordNow) &&
                    field.wordPos[field.wordsList.IndexOf(Player.wordNow)][Player.wordNow.Length - 1] % field.xSize == X)
                {
                    for (int i = 0; i < Player.coordStory.Count; i++)
                    {
                        int x = Player.coordStory[i][0];
                        int y = Player.coordStory[i][1];

                        field.cellColor[x, y, 0] = ConsoleColor.Blue;
                        field.cellColor[x, y, 1] = ConsoleColor.Blue;
                    }

                    Player.wordsList.Add(Player.wordNow);
                }
                else
                {
                    if (field.wordsList.Contains(Player.wordNow))
                        Write.DrawWord("Попробуйте выделить это слово по-другому", field.xSize, Player.wordsList.Count);

                    else if ((allWords as IList<string>).Contains(Player.wordNow))
                        Write.DrawWord("Данное слово не загадано на этом уровне ):", field.xSize, Player.wordsList.Count);

                    else
                        Write.DrawWord("Данного слова нет в словаре", field.xSize, Player.wordsList.Count);
                }

                BrakeFilling(field,X,Y);
            }

            isEnter = !isEnter;
        }

        static public void BrakeFilling(Field field,int X,int Y)
        {
            for (int i = 0; i < Player.coordStory.Count; i++)
            {
                int x = Player.coordStory[i][0];
                int y = Player.coordStory[i][1];

                Write.DrawFieldItem(x, y, field.cellColor[x, y, 0], field.cellColor[x, y, 1], field);
            }
            Write.DrawFieldItem(X, Y, ConsoleColor.DarkGray, ConsoleColor.White, field);

            Player.wordNow = string.Empty;
            Player.coordStory.RemoveRange(0, Player.coordStory.Count);
        }
    }
}
