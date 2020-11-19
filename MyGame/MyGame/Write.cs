using System;
using System.Collections.Generic;
using System.Text;

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
            return Console.ReadLine();
        }
    }
}
