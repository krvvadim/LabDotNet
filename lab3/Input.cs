using System;
using System.Collections.Generic;
using lab3.Figure;

namespace lab3
{
    public class Input
    {
        public static IFigure CreateSquare()
        {
            Console.Write("Enter side of the square: ");
            int side = int.Parse(Console.ReadLine());
            Console.WriteLine();

            IFigure square = new Square(side);
            IFigure cloneSquare = square.CreateFigure();

            return cloneSquare;
        }

        public static IFigure CreateCircle()
        {
            Console.Write("Enter radius for circle: ");
            int radius = int.Parse(Console.ReadLine());
            Console.WriteLine();

            IFigure circle = new Circle(radius);
            IFigure cloneCircle = circle.CreateFigure();
            return cloneCircle;
        }

        public static IFigure CreateTriangle()
        {
            Console.Write("Enter side A of the triangle: ");
            int sideA = int.Parse(Console.ReadLine());
            Console.Write("Enter side B of the triangle: ");
            int sideB = int.Parse(Console.ReadLine());
            Console.Write("Enter side C of the triangle: ");
            int sideC = int.Parse(Console.ReadLine());
            Console.WriteLine();

            IFigure triangle = new Triangle(sideA, sideB, sideC);
            IFigure cloneTriangle = triangle.CreateFigure();
            return cloneTriangle;
        }

        public static IFigure CreateParallelogram()
        {
            Console.Write("Enter side A of the parallelogram: ");
            int sideA = int.Parse(Console.ReadLine());
            Console.Write("Enter side B of the parallelogram: ");
            int sideB = int.Parse(Console.ReadLine());
            Console.Write("Enter height of the parallelogram: ");
            int height = int.Parse(Console.ReadLine());
            Console.WriteLine();

            IFigure parallelogram = new Parallelogram(sideA, sideB, height);
            IFigure cloneParallelogram = parallelogram.CreateFigure();
            return cloneParallelogram;
        }


        public static IFigure CreateCompositeFigures()
        {
            List<IFigure> selectedFigures = new List<IFigure>();
            int figureMenu;
            do
            {
                Console.WriteLine("Choose a figure to add to the composite (or '5' to exit):");
                Console.WriteLine("   1.square");
                Console.WriteLine("   2.circle");
                Console.WriteLine("   3.triangle");
                Console.Write("   4.parallelogram: ");

                figureMenu = int.Parse(Console.ReadLine());
                switch (figureMenu)
                {
                    case 1:
                        IFigure square = Input.CreateSquare();
                        selectedFigures.Add(square);
                        break;
                    case 2:
                        IFigure circle = Input.CreateCircle();
                        selectedFigures.Add(circle);
                        break;
                    case 3:
                        IFigure triangle = Input.CreateTriangle();
                        selectedFigures.Add(triangle);
                        break;
                    case 4:
                        IFigure parallelogram = Input.CreateParallelogram();
                        selectedFigures.Add(parallelogram);
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter a valid figure type or 'e' to exit.");
                        break;
                }
            } while (figureMenu != 5);

            IFigure compositeFigure = new CompositeFigure(selectedFigures);
            IFigure cloneCompositeFigure = compositeFigure.CreateFigure();

            Console.Write("Show created comosite figure? (0/1): ");
            int show = int.Parse(Console.ReadLine());
            if (show == 1)
            {
                Console.Write($"\nComposite figures: ");
                foreach (IFigure compositeFig in selectedFigures)
                {
                    Console.Write(compositeFig.GetType().Name + " ");
                }
                Console.WriteLine("\nComposite figure area: " + compositeFigure.GetArea());
                Console.WriteLine("Composite figure perimeter: " + compositeFigure.GetPerimeter());
            }
            else
            {
                Console.WriteLine("OK");
            }
            return cloneCompositeFigure;
        }
    }
}
