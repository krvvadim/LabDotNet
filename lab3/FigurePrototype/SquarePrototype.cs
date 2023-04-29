using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab3.Figure;

namespace lab3.FigurePrototype
{
    public class SquarePrototype : IFigurePrototype
    {
        public double Side { get; set; }

        public SquarePrototype(double side)
        {
            Side = side;
        }

        public IFigure CreateFigure()
        {
            return new Square(Side);
        }
    }
}
