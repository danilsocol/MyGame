using System;
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
            field.CreateNewField(5, 5);

            Write.WriteField(field);
            Write.DrawFieldItem(0, 0, field);

            
            bool enter = false;
            int x = 0, y = 0;

            do
            {
                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.Enter)
                {
                    enter = !enter;

                    if (enter)
                    {

                    }
                }

                if (key == ConsoleKey.UpArrow  && y > 0) y--; 
                if (key == ConsoleKey.DownArrow && y < 4 ) y++;
                if (key == ConsoleKey.RightArrow && x < 4 ) x++;
                if (key == ConsoleKey.LeftArrow  && x > 0) x--;

                Write.DrawFieldItem(x, y, field);



            } while (true);
        }

        static void Continue()
        {
            Console.WriteLine("Тут однажды будет Продолжить");
        }

        static void Rating()
        {
            Console.WriteLine("Тут однажды будет Рейтинг");
        }

        static void Exit()
        {
            Console.WriteLine("Тут однажды будет Выход");
        }
    }
}
