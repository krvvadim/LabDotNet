using lab4.Models.ProductModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Models.ProductModels.ComputerComponentsModels
{
    public class PowerSupplyUnit : Product
    {
        public int Power { get; set; }

        public PowerSupplyUnit() : base()
        {
            Power = 0;
        }

        public PowerSupplyUnit(string name, string article, double price, int power)
            : base(name, article, price, ProductCategory.PowerSupplyUnit)
        {
            Power = power;
        }

        public PowerSupplyUnit(string name, string article, double price, ProductCategory category, int power) 
            : base(name, article, price, category)
        {
            Power = power;
        }

        public override void Show()
        {
            Console.WriteLine($"Power supply unit: {Name}. Power: {Power}. Price: {Price.ToString("C")}. Article: {Article}.");
        }
    }
}
