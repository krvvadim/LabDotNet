﻿using System;
using System.Collections.Generic;
using System.Text;
using lab3.Figure;

namespace lab3
{
    /*Реалізувати задачу створення різних геометричних фігур. Повинно бути реалізовано створення декількох фігур з різними характеристиками та комбінацій фігур.*/
    
    //
    //
    //Будемо використовувати Prototype
    //
    //

    // Використання фабричних методів для створення фігур
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            int menu = 0;
            List<IFigure> figures = new List<IFigure>();

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

                menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        IFigure square = Input.CreateSquare();
                        figures.Add(square);
                        break;
                    case 2:
                        IFigure circle = Input.CreateCircle();
                        figures.Add(circle);
                        break;
                    case 3:
                        IFigure triangle = Input.CreateTriangle();
                        figures.Add(triangle);
                        break;
                    case 4:
                        IFigure parallelogram = Input.CreateParallelogram();
                        figures.Add(parallelogram);
                        break;
                    case 5:
                        Output.OutputFigure(figures);
                        break;
                    case 6:
                        IFigure compositeFigures = Input.CreateCompositeFigures();
                        figures.Add(compositeFigures);
                        break;
                    case 7:
                        Console.WriteLine("До побачення!");
                        break;
                    default:
                        Console.WriteLine("Невірне значення. Введіть число від 1 до 7.");
                        break;
                }

            } while (menu != 7);
        }
            
    }

}
