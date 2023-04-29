using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.Figure
{
    public class Parallelogram : IFigure
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double Height { get; set; }

        public Parallelogram(double sideA, double sideB, double height)
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

        public override IFigure CreateFigure()
        {
            return new Parallelogram(SideA, SideB, Height);
        }
    }
}
