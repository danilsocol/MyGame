using System;
using System.ComponentModel.Design;

namespace MyGame
{
    class Program
    {
        static void Main(string[] args)//'╔', '═', '╗' '╚', '═', '╝',║,,120
        {
            int select = 1;

            ReadMenu(select);
            Selection(select);

            Console.Read();
        }
        static void Selection(int select)
        {
            while (true)
            {
                ConsoleKey Key = Console.ReadKey().Key;

                Console.WriteLine(Key);

                if(Key == ConsoleKey.Enter)


                if (select > 1)
                    if (Key == ConsoleKey.W || Key == ConsoleKey.UpArrow)
                        select -= 1;

                if (select < 4)
                    if (Key == ConsoleKey.S || Key == ConsoleKey.DownArrow)
                        select += 1;

                Console.Clear();
                ReadMenu(select);
            }
        }

        static void ReadMenu(int select)
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
            counter++;

        }
        enum Optoins
        {
        }
        static void ReadFream(string text, int select, int counter)
        {
            int numSpace = 50;
            if(text == "   FEELWORDS   ")
            {
                numSpace = 48;
            }

            string line = "";
            for (int i = 0; i < text.Length; i++)
                line += '═';


            CreateSpace(numSpace,  select,  counter);
            Fream('╔', line, '╗', numSpace);

            CreateSpace(numSpace, select, counter);
            Fream('║', text, '║', numSpace);

            CreateSpace(numSpace, select, counter);
            Fream('╚', line, '╝', numSpace);
        }

        static void Fream(char oneChar, string text, char twoChar,int numSpace)
        {
            Console.Write(" ");

            Console.Write(oneChar);
            Console.Write(text);
            Console.WriteLine(twoChar);

            Console.ResetColor();
        }

        static void CreateSpace(int numSpace, int select, int counter)
        {
            for (int i = 0; i < numSpace; i++)
                Console.Write(" ");

            if (select == counter)
                Console.BackgroundColor = ConsoleColor.Red;
        }
    }
}
