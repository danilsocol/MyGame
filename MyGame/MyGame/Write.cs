using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MyGame
{
    class Write
    {
       public static void ReadMenu(int select)
        {
            int counter = 0;

            ReadFream("   FEELWORDS   ", select, counter);
            Console.WriteLine("\n");
            counter++;

            ReadFream(" Новая игра ", select, counter);
            Console.WriteLine("");
            counter++;

            ReadFream(" Продолжить ", select, counter);
            Console.WriteLine("");
            counter++;

            ReadFream(" Рейтинг    ", select, counter);
            Console.WriteLine("");
            counter++;

            ReadFream(" Выход      ", select, counter);
            Console.WriteLine("");
        }
        public static void ReadFream(string text, int select, int counter)
        {
            int numSpace = 50;
            if (text == "   FEELWORDS   ")
                numSpace = 48;

            string line = "";
            for (int i = 0; i < text.Length; i++)
                line += '═';

            CreateSpace(numSpace, select, counter);
            Сell('╔', line, '╗', numSpace);

            CreateSpace(numSpace, select, counter);
            Сell('║', text, '║', numSpace);

            CreateSpace(numSpace, select, counter);
            Сell('╚', line, '╝', numSpace);
        }

        public static void Сell(char oneChar, string text, char twoChar, int numSpace)
        {
            Console.Write(oneChar);
            Console.Write(text);
            Console.WriteLine(twoChar);

            Console.ResetColor();
        }

        public static void CreateSpace(int numSpace, int select, int counter)
        {
            for (int i = 0; i < numSpace; i++)
                Console.Write(" ");

            if (select == counter)
                Console.BackgroundColor = ConsoleColor.Red;
        }

        public static string ReadName()
        {
            
            Console.WriteLine("Введите имя");
            string name = Console.ReadLine();

            string[] oldNames = DataWorker.ReadOldNames();
            string[] oldScore = DataWorker.ReadOldScore();
            //for(int l =0; l< oldNames.Length; l++) { }


            int i = 0;
            do
            {
                if (oldNames[i] == "")
                {
                    Console.Clear();
                    Console.WriteLine("Будет создан новый персонаж");
                    Console.ReadLine();

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
                    break;
                }
                else if (name == oldNames[i])
                {
                    Player.score =Convert.ToInt32(oldScore[i]); //Старые очки
                    break;
                }

                i++;

            } while (true);


            Player.indexPlayer = i;

            return name;
        }

        

        public static void WriteField(Field field)
        {
            WriteFieldLine("┌", "─", "┬", "┐", field.xSize);
            Console.WriteLine();

            for (int y = 0; y < field.ySize; y++)
            {
                Console.Write('│');
                for (int x = 0; x < field.xSize; x++)
                {
                    Console.Write(" ");
                    Console.Write(field.cellLetter[x, y]);
                    Console.Write(" " + "│");
                }
                Console.WriteLine();
                WriteFieldLine("├", "─", "┼", "┤", field.xSize);
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            WriteFieldLine("└", "─", "┴", "┘", field.xSize);

            Console.WriteLine($"\n Score : {Player.newScore}");
            Console.WriteLine($"\nВы нашли:");

            foreach (string item in Player.wordsList)
                Console.WriteLine(item);

            WriteWord(Player.nowWord, field.xSize);
        }

        static void WriteFieldLine(string char1, string char2, string char3, string char4, int num)
        {
            Console.Write(char1 + char2 + char2 + char2);
            for (int i = 0; i < num - 1; i++) Console.Write(char3 + char2 + char2 + char2);
            Console.Write(char4);
        }

        static public void WriteFieldChar(int x, int y, dynamic color1, dynamic color2, Field field)
        {
            Console.SetCursorPosition(x * 4 + 2, y * 2 + 1);
            Console.BackgroundColor = color1;
            Console.ForegroundColor = color2;
            Console.Write(field.cellLetter[x, y]);
            Console.ResetColor();
        }

        static public void WriteWord(string text, int xSize)
        {
            Console.SetCursorPosition(xSize * 4 + 1,  1);
            Console.Write(text);
        }

        static public void Wins()
        {
            Console.Clear();
            Console.WriteLine("Вы победили!");
            Console.WriteLine($"Кол-во ваших очков {Player.score}");
            Player.score = Player.score + Player.newScore;
            Console.WriteLine($"Кол-во ваших очков после победы {Player.newScore}");
            Console.ReadKey(true);


            string[] oldScore = DataWorker.ReadOldScore(); // убрать в др метод

            oldScore[Player.indexPlayer] = Convert.ToString(Player.score);

            StreamWriter scr = new StreamWriter("Score.txt");
            for (int k = 0; k < oldScore.Length; k++)
            {
                scr.WriteLine(oldScore[k]);
            }
            scr.Close();
        }

        static public void WriteRating()
        {
            Console.WriteLine("Топ игроки:\n");

            string[] names = DataWorker.ReadOldNames(); 
            string[] score = DataWorker.ReadOldScore();

            string[] countScore = new string[score.Length];

            for(int l=0;l< countScore.Length; l++)
            {
                countScore[l] = score[l];
            }


            int[] topTenIndex = new int[10];


           // int max = Convert.ToInt32(score[0]);
            topTenIndex[0] = 0;

            for (int i = 0; i < 10; i++)
            {
                int max = -1;
                for(int j = 0; j < countScore.Length-1; j++)
                {
                   if(max <= Convert.ToInt32(countScore[j]))
                   {
                        max = Convert.ToInt32(countScore[j]);
                        topTenIndex[i] = j;
                   }
                }
                countScore[topTenIndex[i]] = "-2";
            }

            for(int k = 0; k < 10; k++)
            {
                Console.WriteLine($"{names[topTenIndex[k]]}   {score[topTenIndex[k]]}");
            }

        }
    }

}
