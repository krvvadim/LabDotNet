using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    /*Реалізувати задачу створення різних геометричних фігур. Повинно бути реалізовано створення декількох фігур з різними характеристиками та комбінацій фігур.*/
    /*Будемо використовувати Factory method*/

    // Використання фабричних методів для створення фігур
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            int menu = 0;
            List<Figure> figures = new List<Figure>();

            do
            {
                Console.WriteLine("Menu: ");
                Console.WriteLine("   1. Створити квадрат");
                Console.WriteLine("   2. Створити коло");
                Console.WriteLine("   3. Створити трикутник");
                Console.WriteLine("   4. Створити паралелограм");
                Console.WriteLine("   5. Показати інформацію про всі фігури");
                Console.WriteLine("   6. Створити складну фігуру з вказаних");
                Console.Write("   7. Вийти: ");

                try
                {
                    menu = int.Parse(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:
                            Figure square = InputOutput.CreateSquare();
                            figures.Add(square);
                            break;
                        case 2:
                            Figure circle = InputOutput.CreateCircle();
                            figures.Add(circle);
                            break;
                        case 3:
                            Figure triangle = InputOutput.CreateTriangle();
                            figures.Add(triangle);
                            break;
                        case 4:
                            Figure parallelogram = InputOutput.CreateParallelogram();
                            figures.Add(parallelogram);
                            break;
                        case 5:
                            InputOutput.OutputFigure(figures);
                            break;
                        case 6:
                            Figure compositeFigures = InputOutput.CreateCompositeFigures();
                            figures.Add(compositeFigures);
                            break;
                        case 7:
                            Console.WriteLine("До побачення!");
                            break;
                        default:
                            Console.WriteLine("Невірне значення. Введіть число від 1 до 7.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (menu != 7);
        }
            
    }

}
