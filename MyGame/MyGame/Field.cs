using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace MyGame
{
    class Field
    {
        static Random rnd = new Random();
        public int xSize, ySize;
        public char[,] cellLetter;

        public void CreateNewField(int xXx,int yYy)
        {
             xSize = xXx;
             ySize = yYy;

            List<List<string>> setWords = DataWorker.ReadFile();

            List<string> wordsList = new List<string>();
            List<List<int>> wordPos = new List<List<int>>();

            cellLetter = new char[xSize, ySize];

            char lettersList = '*';


            bool[,] freeСell = new bool[xSize + 2, ySize + 2];
            for (int x = 0; x <= xSize + 1; x++)
                for (int y = 0; y <= ySize + 1; y++)
                {
                    if (x == xSize + 1 || y == ySize + 1 || x == 0 || y == 0) freeСell[x, y] = false;
                    else freeСell[x, y] = true;
                }


            int cellNum = xSize * ySize;
            do
            {
                int x, y;

                int attempts = 0;
                do
                {
                    x = rnd.Next(xSize) + 1;
                    y = rnd.Next(xSize) + 1;
                    attempts++;

                } while (!freeСell[x, y]&& !(attempts>50));

                int direction = FineDirection(freeСell, x, y);

                if (direction == 0)
                {
                    freeСell[x, y] = false;
                    continue;
                }
                else
                {
                    int lenght = 0;
                    wordPos.Add(new List<int>());
                    do
                    {
                        freeСell[x, y] = false;
                        lenght++;
                        cellNum--;
                        wordPos[wordsList.Count].Add((y - 1) * xSize + (x - 1));

                        int localX = x + (-(direction - 2) % 2);
                        int localY = y + ((direction - 3) % 2);

                        if (!freeСell[localX, localY])
                        {
                            direction = FineDirection(freeСell, x, y);
                            if (direction == 0) break;
                            localX = x + (-(direction - 2) % 2);
                            localY = y + (direction - 3) % 2;
                        }
                        x = localX;
                        y = localY;

                        if (lenght == setWords.Count - 1 || (lenght >= 4 && rnd.Next(6) == 0))
                            break;

                    } while (true);

                    if (setWords[lenght].Count > 0)
                    {
                        int randomNum = rnd.Next(setWords[lenght].Count);
                        wordsList.Add(setWords[lenght][randomNum]);
                        setWords[lenght].Remove(wordsList[wordsList.Count - 1]);
                        if (setWords.Count == lenght && setWords[lenght].Count == 0)
                            setWords.RemoveAt(setWords.Count - 1);
                    }
                    else
                    {
                        wordPos.RemoveAt(wordPos.Count - 1);
                    }
                }

            } while (cellNum > 1);

            for (int i = 0; i < wordsList.Count; i++)
            {
                for (int ii = 0; ii < wordsList[i].Length; ii++)
                {
                    int x = wordPos[i][ii] % xSize;
                    int y = wordPos[i][ii] / xSize;
                    cellLetter[x, y] = wordsList[i][ii];
                }
            }

            for (int y = 0; y < ySize; y++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    if (cellLetter[x, y] == '\0')
                        cellLetter[x, y] = lettersList;
                }
            }
        }


        private static int FineDirection(bool[,] cell,int x, int y)
        {
            int finalDirection;

            List<int> direction = new List<int>() { 1, 2, 3, 4 };

            if (!cell[x + 1, y]) direction.Remove(1);
            if (!cell[x , y-1]) direction.Remove(2);
            if (!cell[x-1, y]) direction.Remove(3);
            if (!cell[x , y+1]) direction.Remove(4);

            if (direction.Count != 0) finalDirection = direction[rnd.Next(direction.Count)];
            else finalDirection = 0;

            return finalDirection;

        }



    }
}
