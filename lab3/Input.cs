using System;
using System.Collections.Generic;
using lab3.Figure;
using lab3.FigurePrototype;

namespace lab3
{
    public class Input
    {

        public static IFigure CreateSquare()
        {
            Console.Write("Enter side of the square: ");
            int side = int.Parse(Console.ReadLine());
            Console.WriteLine();

            IFigurePrototype squarePrototype = new SquarePrototype(side);
            IFigure square = squarePrototype.CreateFigure();
            return square;
        }

        public static IFigure CreateCircle()
        {
            Console.Write("Enter radius for circle: ");
            int radius = int.Parse(Console.ReadLine());
            Console.WriteLine();

            IFigurePrototype circlePrototype = new CirclePrototype(radius);
            IFigure circle = circlePrototype.CreateFigure();
            return circle;
        }

        public static IFigure CreateTriangle()
        {
            Console.Write("Enter side A of the triangle: ");
            int side_A = int.Parse(Console.ReadLine());
            Console.Write("Enter side B of the triangle: ");
            int side_B = int.Parse(Console.ReadLine());
            Console.Write("Enter side C of the triangle: ");
            int side_C = int.Parse(Console.ReadLine());
            Console.WriteLine();

            IFigurePrototype trianglePrototype = new TrianglePrototype(side_A, side_B, side_C);
            IFigure triangle = trianglePrototype.CreateFigure();
            return triangle;
        }

        public static IFigure CreateParallelogram()
        {
            Console.Write("Enter side A of the parallelogram: ");
            int side_A = int.Parse(Console.ReadLine());
            Console.Write("Enter side B of the parallelogram: ");
            int side_B = int.Parse(Console.ReadLine());
            Console.Write("Enter height of the parallelogram: ");
            int height = int.Parse(Console.ReadLine());
            Console.WriteLine();

            IFigurePrototype parallelogramPrototype = new ParalelogramPrototype(side_A, side_B, height);
            IFigure parallelogram = parallelogramPrototype.CreateFigure();
            return parallelogram;
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
            CompositeFigure compositeFigure = new CompositeFigure { Figures = selectedFigures };

            Console.Write($"\nComposite figures: ");
            foreach (IFigure compositeFig in selectedFigures)
            {
                Console.Write(compositeFig.GetType().Name + " ");
            }
            Console.WriteLine("\nComposite figure area: " + compositeFigure.GetArea());
            Console.WriteLine("Composite figure perimeter: " + compositeFigure.GetPerimeter());
            return compositeFigure;
        }
    }
}
