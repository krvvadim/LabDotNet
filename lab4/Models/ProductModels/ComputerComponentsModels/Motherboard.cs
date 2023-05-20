using lab4.Models.ProductModels.ComputerComponentsModels.Enums;
using lab4.Models.ProductModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Models.ProductModels.ComputerComponentsModels
{
    public class Motherboard : Product
    {
        public string Socket { get; set; }
        public string Chipset { get; set; }
        public MotherboardType Type { get; set; }

        public Motherboard() : base()
        {
            Socket = string.Empty;
            Chipset = string.Empty;
            Type = new MotherboardType();
        }

        public Motherboard(string name, string article, double price, string socket, string chipset, MotherboardType type)
            : base(name, article, price, ProductCategory.Motherboard)
        {
            Socket = socket;
            Chipset = chipset;
            Type = type;
        }

        public Motherboard(string name, string article, double price, ProductCategory category, string socket, string chipset, MotherboardType type) 
            : base(name, article, price, category)
        {
            Socket = socket;
            Chipset = chipset;
            Type = type;
        }  

        public override void Show()
        {
            Console.WriteLine($"Motherboard: {Name}. Chipset: {Chipset}. Socket: {Socket}. " +
                $"Type: {MotherboardTypeToString(Type)}. Price: {Price.ToString("C")}. Article: {Article}.");
        }
    }
}
