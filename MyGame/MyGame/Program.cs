using System;
using System.ComponentModel.Design;

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
                ConsoleKey Key = Console.ReadKey().Key;

                if(Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    switch (select) 
                    {
                        case 1:
                            NewGame.Start();
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
                    if (Key == ConsoleKey.W || Key == ConsoleKey.UpArrow)
                        select -= 1;

                if (select < 4)
                    if (Key == ConsoleKey.S || Key == ConsoleKey.DownArrow)
                        select += 1;

                Console.Clear();
                Write.ReadMenu(select);
            }
        }
        //static void NewGame()
        //{
        //    Console.WriteLine("Введите имя");
        //    string Name = Console.ReadLine();
        //}

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
