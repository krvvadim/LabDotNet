using lab4.Models.ProductModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Models.ProductModels.ComputerComponentsModels
{
    public class Processor : Product
    {
        public int Cores { get; set; }
        public int Threads { get; set; }
        public int Frequency { get; set; }
        public string Socket { get; set; }

        public Processor() : base()
        {
            Cores = 0;
            Threads = 0;
            Frequency = 0;
            Socket = string.Empty;
        }
        public Processor(string name, string article, double price, int cores, int threads, int frequency, string socket) :
           base(name, article, price, ProductCategory.Processor)
        {
            Cores = cores;
            Threads = threads;
            Frequency = frequency;
            Socket = socket;
        }

        public Processor(string name, string article, double price, ProductCategory category, int cores, int threads, int frequency, string socket) :
            base(name, article, price, category)
        {
            Cores = cores;
            Threads = threads;
            Frequency = frequency;
            Socket = socket;
        }


        public override void Show()
        {
            Console.WriteLine($"Processor: {Name}. Cores: {Cores}. Threads: {Threads}. Frequency: {Frequency}." +
                $" Socket: {Socket}. Price: {Price.ToString("C")}. Article: {Article}.");
        }
    }
}
