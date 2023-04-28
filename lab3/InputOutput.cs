using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class InputOutput
    {

        public static Figure CreateSquare()
        {
            Console.Write("Enter side of the square: ");
            int side = int.Parse(Console.ReadLine());
            Console.WriteLine();

            IFigureFactory squareFactory = new SquareFactory(side);
            Figure square = squareFactory.CreateFigure();
            return square;
        }

        public static Figure CreateCircle()
        {
            Console.Write("Enter radius for circle: ");
            int radius = int.Parse(Console.ReadLine());
            Console.WriteLine();

            IFigureFactory circleFactory = new CircleFactory(radius);
            Figure circle = circleFactory.CreateFigure();
            return circle;
        }

        public static Figure CreateTriangle()
        {
            Console.Write("Enter side A of the triangle: ");
            int side_A = int.Parse(Console.ReadLine());
            Console.Write("Enter side B of the triangle: ");
            int side_B = int.Parse(Console.ReadLine());
            Console.Write("Enter side C of the triangle: ");
            int side_C = int.Parse(Console.ReadLine());
            Console.WriteLine();

            IFigureFactory triangleFactory = new TriangleFactory(side_A, side_B, side_C);
            Figure triangle = triangleFactory.CreateFigure();
            return triangle;
        }

        public static Figure CreateParallelogram()
        {
            Console.Write("Enter side A of the parallelogram: ");
            int side_A = int.Parse(Console.ReadLine());
            Console.Write("Enter side B of the parallelogram: ");
            int side_B = int.Parse(Console.ReadLine());
            Console.Write("Enter height of the parallelogram: ");
            int height = int.Parse(Console.ReadLine());
            Console.WriteLine();

            IFigureFactory parallelogramFactory = new ParalelogramFactory(side_A, side_B, height);
            Figure parallelogram = parallelogramFactory.CreateFigure();
            return parallelogram;
        }

        public static void OutputFigure(List<Figure> figures)
        {
            Console.WriteLine("\nІнформація про всі фігури:");
            foreach (Figure figure in figures)
            {
                Console.WriteLine("Тип фігури: " + figure.GetType().Name);
                Console.WriteLine("Площа: " + figure.GetArea());
                Console.WriteLine("Периметр: " + figure.GetPerimeter() + "\n");
            }
        }

        public static Figure CreateCompositeFigures()
        {
            List<Figure> selectedFigures = new List<Figure>();
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
                        Figure square = InputOutput.CreateSquare();
                        selectedFigures.Add(square);
                        break;
                    case 2:
                        Figure circle = InputOutput.CreateCircle();
                        selectedFigures.Add(circle);
                        break;
                    case 3:
                        Figure triangle = InputOutput.CreateTriangle();
                        selectedFigures.Add(triangle);
                        break;
                    case 4:
                        Figure parallelogram = InputOutput.CreateParallelogram();
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
            foreach (Figure compFig in selectedFigures)
            {
                Console.Write(compFig.GetType().Name + " ");
            }
            Console.WriteLine("\nComposite figure area: " + compositeFigure.GetArea());
            Console.WriteLine("Composite figure perimeter: " + compositeFigure.GetPerimeter());
            return compositeFigure;
        }
    }
}
