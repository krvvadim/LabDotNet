using lab4.Models.ProductModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Models.ProductModels.ComputerComponentsModels
{
    public class SSD : Product
    {
        public int Memory { get; set; }
        public int Speed { get; set; }
        public SSD() : base()
        {
            Memory = 0;
            Speed = 0;
        }

        public SSD(string name, string article, double price, int memory, int speed) 
            : base(name, article, price, ProductCategory.SSD)
        {
            Memory = memory;
            Speed = speed;
        }

        public SSD(string name, string article, double price, ProductCategory category, int memory, int speed) 
            : base(name, article, price, category)
        {
            Memory = memory;
            Speed = speed;
        }

        public override void Show()
        {
            Console.WriteLine($"SSD: {Name}. Memory: {Memory}. Speed: {Speed}." +
                $" Type: Price: {Price.ToString("C")}. Article: {Article}.");
        }
    }
}
