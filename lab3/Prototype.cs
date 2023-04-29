using System;
using System.Collections.Generic;

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
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public override double GetPerimeter()
        {
            return SideA + SideB + SideC;
        }

        public override double GetArea()
        {
            double p = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
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
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double Height { get; set; }

        public Paralelogram(double sideA, double sideB, double height)
        {
            SideA = sideA;
            SideB = sideB;
            Height = height;
        }

        public override double GetArea()
        {
            return SideA * Height;
        }

        public override double GetPerimeter()
        {
            return 2 * SideA + 2 * SideB;
        }
    }

    // Створення фабричних методів для кожної фігури
    public interface IFigurePrototype
    {
        Figure CreateFigure();
    }

    public class SquarePrototype : IFigurePrototype
    {
        public double Side { get; set; }

        public SquarePrototype(double side)
        {
            Side = side;
        }

        public Figure CreateFigure()
        {
            return new Square(Side);
        }
    }

    public class TrianglePrototype : IFigurePrototype
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public TrianglePrototype(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public Figure CreateFigure()
        {
            return new Triangle(SideA, SideB, SideC);
        }
    }

    public class CirclePrototype : IFigurePrototype
    {
        public double Radius { get; set; }

        public CirclePrototype(double radius)
        {
            Radius = radius;
        }

        public Figure CreateFigure()
        {
            return new Circle(Radius);
        }
    }

    public class ParalelogramPrototype : IFigurePrototype
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double Height { get; set; }

        public ParalelogramPrototype(double sideA, double sideB, double height)
        {
            SideA = sideA;
            SideB = sideB;
            Height = height;
        }

        public Figure CreateFigure()
        {
            return new Paralelogram(SideA, SideB, Height);
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
