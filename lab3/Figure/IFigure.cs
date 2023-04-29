using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.Figure
{
    // Створення абстрактного класу фігури
    public abstract class IFigure
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }
}
