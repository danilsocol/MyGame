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

        public static void WriteField(Field field)
        {
            DrawFieldLine("┌", "─", "┬", "┐", field.xSize);
            Console.WriteLine();

            for (int y = 0; y < field.ySize; y++)
            {
                Console.Write('│');
                for (int x = 0; x < field.xSize; x++)
                {
                    Console.Write(" ");
                    Console.Write(field.cellLetter[x, y]);
                    Console.ResetColor();
                    Console.Write(" " + "│");
                }
                Console.WriteLine();
                DrawFieldLine("├", "─", "┼", "┤", field.xSize);
                Console.WriteLine();
            }

            Console.SetCursorPosition(0, Console.CursorTop - 1);
            DrawFieldLine("└", "─", "┴", "┘", field.xSize);
        }

        static void DrawFieldLine(string char1, string char2, string char3, string char4, int num)
        {
            Console.Write(char1 + char2 + char2 + char2);
            for (int i = 0; i < num - 1; i++) Console.Write(char3 + char2 + char2 + char2);
            Console.Write(char4);
        }

        static public void DrawFieldItem(int x, int y, dynamic color1, dynamic color2, Field field)
        {
            Console.SetCursorPosition(x * 4 + 2, y * 2 + 1);
            Console.BackgroundColor = color1;
            Console.ForegroundColor = color2;
            Console.Write(field.cellLetter[x, y]);
            Console.ResetColor();
        }

        static public void DrawWord(string text, int xSize, int num)
        {
            Console.SetCursorPosition(xSize * 4 + 2, num + 1);
            Console.Write(text);
        }
    }

}
