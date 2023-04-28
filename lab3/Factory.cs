using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    // Створення абстрактного класу фігури
    public abstract class Figure
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }

    // Створення класів-нащадків для різних фігур(квадрат, трикутник, круг, паралелограм)
    public class Square : Figure
    {
        public double Side { get; set; }

        public Square(double side)
        {
            Side = side;
        }

        public override double GetArea()
        {
            return Side * Side;
        }

        public override double GetPerimeter()
        {
            return 4 * Side;
        }
    }

    public class Triangle : Figure
    {
        public double Side_A { get; set; }
        public double Side_B { get; set; }
        public double Side_C { get; set; }

        public Triangle(double side_a, double side_b, double side_c)
        {
            Side_A = side_a;
            Side_B = side_b;
            Side_C = side_c;
        }

        public override double GetPerimeter()
        {
            return Side_A + Side_B + Side_C;
        }

        public override double GetArea()
        {
            double p = (Side_A + Side_B + Side_C) / 2;
            return Math.Sqrt(p * (p - Side_A) * (p - Side_B) * (p - Side_C));
        }
    }

    public class Circle : Figure
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }

    public class Paralelogram : Figure
    {
        public double Side_A { get; set; }
        public double Side_B { get; set; }
        public double Height { get; set; }

        public Paralelogram(double side_a, double side_b, double height)
        {
            Side_A = side_a;
            Side_B = side_b;
            Height = height;
        }

        public override double GetArea()
        {
            return Side_A * Height;
        }

        public override double GetPerimeter()
        {
            return 2 * Side_A + 2 * Side_B;
        }
    }

    // Створення фабричних методів для кожної фігури
    public interface IFigureFactory
    {
        Figure CreateFigure();
    }

    public class SquareFactory : IFigureFactory
    {
        public double Side { get; set; }

        public SquareFactory(double side)
        {
            Side = side;
        }

        public Figure CreateFigure()
        {
            return new Square(Side);
        }
    }

    public class TriangleFactory : IFigureFactory
    {
        public double Side_A { get; set; }
        public double Side_B { get; set; }
        public double Side_C { get; set; }

        public TriangleFactory(double side_a, double side_b, double side_c)
        {
            Side_A = side_a;
            Side_B = side_b;
            Side_C = side_c;
        }

        public Figure CreateFigure()
        {
            return new Triangle(Side_A, Side_B, Side_C);
        }
    }

    public class CircleFactory : IFigureFactory
    {
        public double Radius { get; set; }

        public CircleFactory(double radius)
        {
            Radius = radius;
        }

        public Figure CreateFigure()
        {
            return new Circle(Radius);
        }
    }

    public class ParalelogramFactory : IFigureFactory
    {
        public double Side_A { get; set; }
        public double Side_B { get; set; }
        public double Height { get; set; }

        public ParalelogramFactory(double side_a, double side_b, double height)
        {
            Side_A = side_a;
            Side_B = side_b;
            Height = height;
        }

        public Figure CreateFigure()
        {
            return new Paralelogram(Side_A, Side_B, Height);
        }
    }

    // клас для складання фігур
    public class CompositeFigure : Figure
    {
        public List<Figure> Figures { get; set; }

        public override double GetArea()
        {
            double area = 0;
            foreach (var figure in Figures)
            {
                area += figure.GetArea();
            }
            return area;
        }

        public override double GetPerimeter()
        {
            double perimeter = 0;
            foreach (var figure in Figures)
            {
                perimeter += figure.GetPerimeter();
            }
            return perimeter;
        }
    }
}
