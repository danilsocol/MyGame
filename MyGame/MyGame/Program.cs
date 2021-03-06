﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyGame
{
    class Program
    {
        static void Main(string[] args)//'╔', '═', '╗' '╚', '═', '╝',║,,120
        {
            int select = 1;

            Write.ReadMenu(select);
            Selection(select);

            Console.Read();
        }
        static void Selection(int select)
        {
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;

                if(key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    switch (select) 
                    {
                        case 1:
                            CreateUser();
                            GameActions();
                            break;

                        case 2:
                            Continue();
                            break;

                        case 3:
                            Rating();
                            break;

                        case 4:
                            Exit();
                            break;
                    }
                    break;
                }
                if (select > 1)
                    if (key == ConsoleKey.W || key == ConsoleKey.UpArrow)
                        select -= 1;

                if (select < 4)
                    if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
                        select += 1;

                Console.Clear();
                Write.ReadMenu(select);
            }
        }
        public static void CreateUser()
        {
            string User;
            do
            {
                User = Write.ReadName();
                Console.Clear();

            } while (User.Length == 0);
        }

        public static void GameActions()
        {
            Field field = new Field();
            field.CreateField(5, 5);

            Write.WriteField(field);
            Write.WriteFieldChar(0, 0, ConsoleColor.Red, ConsoleColor.White, field);

            bool enter = false;
            int preX, preY, x = 0, y = 0;

            do
            {
                preX = x;
                preY = y;

                if (Player.wordsList.Count == field.wordsList.Count)
                {
                    Player.newScore += 400;
                    Write.Wins();
                    Player.score = Player.score + Player.newScore;
                    DataWorker.Victory();
                    break;
                }

                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.UpArrow  && preY > 0) y--; 
                if (key == ConsoleKey.DownArrow && preY < 4 ) y++;
                if (key == ConsoleKey.RightArrow && preX < 4 ) x++;
                if (key == ConsoleKey.LeftArrow  && preX > 0) x--;

                Console.SetCursorPosition(preX * 4 + 3, preY * 2 + 1);

                if (preX != x || preY != y)
                {
                    Game.MoveAction(preX,preY,x, y, field, enter);
                }

                if (key == ConsoleKey.Enter)
                {
                    Game.EnterAction(x, y, field, ref enter, DataWorker.ReadFile());
                }

                if (key == ConsoleKey.Escape)
                {
                    if (enter)
                    {
                        Game.Stop(field, x, y);
                        Write.WriteWord(new string(' ', Console.WindowWidth - (field.xSize * 4 + 2)), field.xSize);

                        enter = false;
                    }
                    else
                    {
                        Write.WriteWord("Вы уверены, что хотите выйти? (Прогресс будет потерян)", field.xSize);
                        Console.WriteLine($"Кол-во ваших очков {Player.score}");
                        key = Console.ReadKey().Key;

                        if (key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Write.WriteWord(" ", field.xSize+1);
                            Console.SetCursorPosition(preX * 4 + 3, preY * 2 + 1);
                        }
                    }
                }
            } while (true);
        }

        static void Continue()
        {
            Console.WriteLine("Тут однажды будет Продолжить");
        }

        static void Rating()
        {
            Write.WriteRating();
        }

        static void Exit()
        {
            Environment.Exit(0);
        }

    }
}
