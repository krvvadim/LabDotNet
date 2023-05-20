using lab4.Models.ProductModels.ComputerComponentsModels.Enums;
using lab4.Models.ProductModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Models.ProductModels.ComputerComponentsModels
{
    public class Cooler : Product
    {
        public CoolerType Type { get; set; }
        public Cooler() : base()
        {
            Type = new CoolerType();
        }

        public Cooler(string name, string article, double price, CoolerType type)
            : base(name, article, price, ProductCategory.Cooler)
        {
            Type = type;
        }


        public Cooler(string name, string article, double price, ProductCategory category, CoolerType type)
            : base(name, article, price, category)
        {
            Type = type;
        }

        public override void Show()
        {
            Console.WriteLine($"Cooler: {Name}. Type: {CoolerTypeToString(Type)}." +
                $" Type: Price: {Price.ToString("C")}. Article: {Article}.");
        }

       
    }
}
