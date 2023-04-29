using System;
using System.Collections.Generic;
using lab3.Figure;

namespace lab3.FigurePrototype
{
    // Створення фабричних методів для кожної фігури
    public interface IFigurePrototype
    {
        IFigure CreateFigure();
    }
}
