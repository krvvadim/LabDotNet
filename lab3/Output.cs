using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class Output
    {
        public static void OutputFigure(List<Figure> figures)
        {
            Console.WriteLine("\nІнформація про всі фігури:");
            foreach (Figure figure in figures)
            {
                Console.WriteLine("Тип фігури: " + figure.GetType().Name);
                Console.WriteLine("Площа: " + figure.GetArea());
                Console.WriteLine("Периметр: " + figure.GetPerimeter() + "\n");
            }
        }
    }
}
