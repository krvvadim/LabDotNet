using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab3.Figure;

namespace lab3.FigurePrototype
{
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

        public IFigure CreateFigure()
        {
            return new Parallelogram(SideA, SideB, Height);
        }
    }
}
