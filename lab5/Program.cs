using System;
using System.Collections.Generic;

namespace lab5
{
    public class Program
    {
        static void Main(string[] args)
        {
            int symb = 0; ;
            char player = 'X';
            Originator originator = new Originator();
            Caretaker caretaker = new Caretaker();
            caretaker.SaveState(originator.SaveState());
            do
            {
                Console.WriteLine("\n1.Правила гри\n" +
                    "2.Налаштування(Х/О)\n" +
                    "3.Почати гру(гравець з гравцем)\n" +
                    "4.Вихід");
                Console.Write("Enter num: ");
                symb = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (symb)
                {
                    case 1:
                        GameFunctionality.ShowRules();
                        break;
                    case 2:
                        player = GameFunctionality.SetSettings();
                        break;
                    case 3:
                        GameFunctionality.StartGame(player);
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("\nError symbol");
                        break;
                }
            }
            while (symb != 4);
        }
    }
}
