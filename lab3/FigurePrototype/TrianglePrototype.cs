using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab3.Figure;

namespace lab3.FigurePrototype
{
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

        public IFigure CreateFigure()
        {
            return new Triangle(SideA, SideB, SideC);
        }
    }
}
