using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.Figure
{
    // Створення класів-нащадків для різних фігур(квадрат, трикутник, круг, паралелограм)
    public class Square : IFigure
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

        public override IFigure CreateFigure()
        {
            return new Square(Side);
        }
    }
}
