using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class Caretaker
    {
        private Stack<Memento> mementos = new Stack<Memento>();

        public void SaveState(Memento memento)
        {
            mementos.Push(memento);
        }

        public Memento Undo()
        {
            if (mementos.Count > 0)
            {
                return mementos.Pop();
            }
            else
            {
                Console.WriteLine("No more moves to undo.");
                return null;
            }
        }
    }
}
