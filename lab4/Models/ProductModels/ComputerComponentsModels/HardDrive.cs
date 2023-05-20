using lab4.Models.ProductModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Models.ProductModels.ComputerComponentsModels
{
    public class HardDrive : Product
    {
        public int Memory { get; set; }
        public int RPM { get; set; }
        public double FormFactor { get; set; }

        public HardDrive() : base()
        {
            Memory = 0;
            RPM = 0;
            FormFactor = 0;
        }

        public HardDrive(string name, string article, double price, int memory, int rpm, double formFactor)
            : base(name, article, price, ProductCategory.HardDrive)
        {
            Memory = memory;
            RPM = rpm;
            FormFactor = formFactor;
        }

        public HardDrive(string name, string article, double price, ProductCategory category, int memory, int rpm, double formFactor) 
            : base(name, article, price, category)
        {
            Memory = memory;
            RPM = rpm;
            FormFactor = formFactor;
        }

        public override void Show()
        {
            Console.WriteLine($"Hard drive: {Name}. Memory: {Memory}. RPM: {RPM}. Form-factor: {FormFactor}\"." +
                $" Type: Price: {Price.ToString("C")}. Article: {Article}.");
        }
    }
}
