using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class Memento
    {
        public char[,] Board { get; }

        public Memento(char[,] board)
        {
            Board = board;
        }
    }
}
