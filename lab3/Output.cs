using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab3.Figure;

namespace lab3
{
    public class Output
    {
        public static void OutputFigure(List<IFigure> figures)
        {
            Console.WriteLine("\nІнформація про всі фігури:");
            foreach (IFigure figure in figures)
            {
                Console.WriteLine("Тип фігури: " + figure.GetType().Name);
                Console.WriteLine("Площа: " + figure.GetArea());
                Console.WriteLine("Периметр: " + figure.GetPerimeter() + "\n");
            }
        }
    }
}
