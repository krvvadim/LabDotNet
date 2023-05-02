using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.Figure
{
    // клас для складання фігур від абстрактного класу
    public class CompositeFigure : IFigure
    {
        public List<IFigure> Figures { get; set; }

        public CompositeFigure(List<IFigure> figr)
        {
            Figures = figr;
        }

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

        public override IFigure CreateFigure()
        {
            return new CompositeFigure(Figures);
        }
    }
}
