using System;

namespace MyGame
{
    class Program
    {
        static void Main(string[] args)//'╔', '═', '╗' '╚', '═', '╝',║,,120
        {
            ReadMenu();


            Console.Read();
        }
        static void ReadMenu()
        {
            ReadFream("   FEELWORDS   ");
            Console.WriteLine("\n");

            ReadFream(" Новая игра ");
            Console.WriteLine("");

            ReadFream(" Продолжить ");
            Console.WriteLine("");

            ReadFream(" Рейтинг    ");
            Console.WriteLine("");

            ReadFream(" Выход      ");
            Console.WriteLine("");

        }
        static void ReadFream(string text)
        {
            int numSpace = 50;
            if(text == "   FEELWORDS   ")
            {
                numSpace = 48;
            }

            string line = "";
            for (int i = 0; i < text.Length; i++)
                line += '═';
            
            Fream('╔', line, '╗', numSpace);
            Fream('║', text, '║', numSpace);
            Fream('╚', line, '╝', numSpace);
        }

        static void Fream(char oneChar, string text, char twoChar,int numSpace)
        {
            for (int i = 0; i < numSpace; i++)
                Console.Write(" ");

            //if(text == " Новая игра ")
            //    Console.BackgroundColor = ConsoleColor.Red;
            
            Console.Write(oneChar);
            Console.Write(text);
            Console.WriteLine(twoChar);

            //Console.ResetColor();
        }
    }
}
