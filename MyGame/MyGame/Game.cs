using System;
using System.Collections.Generic;
namespace MyGame
{
    class Game
    {
        static public void MoveAction(int preX,int preY,int x,int y ,Field field, bool isEnter)
        {
            if (!isEnter)
            {
                Write.WriteFieldChar(preX, preY, field.cellColor[preX, preY, 0], field.cellColor[preX, preY, 1], field);

                Write.WriteFieldChar(x, y, ConsoleColor.Red, ConsoleColor.White, field);
            }
            else
            {
                Write.WriteFieldChar(preX, preY, ConsoleColor.Gray, ConsoleColor.Black, field);
                Write.WriteFieldChar(x, y, ConsoleColor.Red, ConsoleColor.White, field);

                Player.nowWord += field.cellLetter[x, y];

                Write.WriteWord(Player.nowWord, field.xSize);

                Player.coordStory.Add(new int[] { x, y });
            }

        }

        static public void EnterAction(int X, int Y,Field field, ref bool isEnter, string[] allWords)
        {
            if (!isEnter)
            {
                Write.WriteWord(new string(' ', Console.WindowWidth - (field.xSize * 4 + 2)), field.xSize);

                if (field.cellColor[X, Y, 0] == ConsoleColor.Black)
                {
                    Write.WriteFieldChar(X, Y, ConsoleColor.Gray, ConsoleColor.Black, field);
                    Player.nowWord += field.cellLetter[X, Y];
                    Write.WriteWord(Player.nowWord, field.xSize);
                    Player.coordStory.Add(new int[] { X, Y });
                }
                else
                    isEnter = !isEnter;
            }
            else
            {
                if (field.wordsList.Contains(Player.nowWord) && field.wordPos[field.wordsList.IndexOf(Player.nowWord)][Player.nowWord.Length - 1] % field.xSize == X)
                {
                    for (int i = 0; i < Player.coordStory.Count; i++)
                    {
                        int x = Player.coordStory[i][0];
                        int y = Player.coordStory[i][1];

                        field.cellColor[x, y, 0] = ConsoleColor.Blue;
                        field.cellColor[x, y, 1] = ConsoleColor.Blue;
                    }

                    Player.wordsList.Add(Player.nowWord);

                    Player.newScore += 100;
                    Console.Clear();
                    Write.WriteField(field);
                }
                else
                {
                    if (field.wordsList.Contains(Player.nowWord))
                        Write.WriteWord("Попробуйте выделить это слово по-другому", field.xSize);

                    else if ((allWords as IList<string>).Contains(Player.nowWord))
                        Write.WriteWord("Данное слово не загадано на этом уровне ):", field.xSize);

                    else
                        Write.WriteWord("Данного слова нет в словаре", field.xSize);
                }

                Stop(field,X,Y);
            }

            isEnter = !isEnter;
        }

        static public void Stop(Field field,int X,int Y)
        {
            for (int i = 0; i < Player.coordStory.Count; i++)
            {
                int x = Player.coordStory[i][0];
                int y = Player.coordStory[i][1];

                Write.WriteFieldChar(x, y, field.cellColor[x, y, 0], field.cellColor[x, y, 1], field);
            }
            Write.WriteFieldChar(X, Y, ConsoleColor.DarkGray, ConsoleColor.White, field);

            Player.nowWord = string.Empty;
            Player.coordStory.RemoveRange(0, Player.coordStory.Count);
        }
    }
}
