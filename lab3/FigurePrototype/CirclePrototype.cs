using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab3.Figure;

namespace lab3.FigurePrototype
{
    public class CirclePrototype : IFigurePrototype
    {
        public double Radius { get; set; }

        public CirclePrototype(double radius)
        {
            Radius = radius;
        }

        public IFigure CreateFigure()
        {
            return new Circle(Radius);
        }
    }
}
